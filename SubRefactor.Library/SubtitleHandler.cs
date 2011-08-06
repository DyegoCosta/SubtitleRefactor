using System.Collections.Generic;
using System.IO;
using SubRefactor.Domain;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace SubRefactor.Library
{
    public class SubtitleHandler
    {
        /// <summary>
        /// Set the subtitle quotes
        /// </summary>
        /// <param name="subtitle">Stream of the original subtitle</param>
        /// <returns></returns>
        public IList<Quote> ReadSubtitle(Stream subtitle)
        {
            string allText;
            IList<Quote> quotes = new List<Quote>();

            using (var sr = new StreamReader(subtitle, Encoding.Default))
                allText = sr.ReadToEnd();

            var indexRegex = new Regex(@"^\d+$");
            var timeRegex = new Regex(@"^([0-9]{2}:){2}[0-9]{2},[0-9]{3}\s-->\s([0-9]{2}:){2}[0-9]{2},[0-9]{3}\s*$");
            var integerRegex = new Regex(@"\d+");

            var quoteLines = Regex.Split(allText, Environment.NewLine + Environment.NewLine);

            foreach(var quoteLine in quoteLines)
            {
                if (string.IsNullOrEmpty(quoteLine))
                    continue;

                var quote = new Quote();

                var lines = Regex.Split(quoteLine, Environment.NewLine);

                foreach (var line in lines)
                {
                    if (indexRegex.IsMatch(line))
                        quote.Index = int.Parse(line);
                    else if (timeRegex.IsMatch(line))
                    {
                        var matches = integerRegex.Matches(line);
                        if (matches.Count != 8)
                            throw new Exception("The selected file is invalid");

                        quote.BeginTimeLine = new TimeSpan(0, int.Parse(matches[0].Value),
                                                           int.Parse(matches[1].Value),
                                                           int.Parse(matches[2].Value),
                                                           int.Parse(matches[3].Value));
                        quote.EndTimeLine = new TimeSpan(0, int.Parse(matches[4].Value),
                                                         int.Parse(matches[5].Value),
                                                         int.Parse(matches[6].Value),
                                                         int.Parse(matches[7].Value));
                    }
                    else
                    {
                        if (quote.QuoteLine == null)
                            quote.QuoteLine = line;
                        else                        
                            quote.QuoteLine += "\r\n" + line;                        
                    }
                }

                quotes.Add(quote);
            }            

            return quotes;
        }

        /// <summary>
        /// Return the subtitle as a Stream
        /// </summary>
        /// <param name="quotes">Lsit of quotes of the subtitle</param>
        /// <returns>Subtitle.srt</returns>
        public MemoryStream WriteSubtitle(IList<Quote> quotes)
        {
            var ms = new MemoryStream();

            using (var sw = new StreamWriter(ms, Encoding.Default))
            {
                foreach (var quote in quotes.OrderBy(q => q.Index))
                {
                    sw.WriteLine(quote.ToString());
                    sw.WriteLine();
                }

                sw.Flush();
            }

            return ms;
        }
    }
}

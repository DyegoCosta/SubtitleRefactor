using System.Collections.Generic;
using System.IO;
using SubRefactor.Domain;

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
            var quote = new Quote();
            IList<Quote> quotes = new List<Quote>();

            string line;
            IList<string> lines = new List<string>();

            using (var sr = new StreamReader(subtitle, new System.Text.UTF7Encoding()))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                sr.Dispose();
            }

            foreach (var item in lines)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (string.IsNullOrEmpty(quote.Index) && string.IsNullOrEmpty(quote.QuoteLine))
                    {
                        quote.Index = item;
                    }
                    else if (string.IsNullOrEmpty(quote.QuoteLine) && string.IsNullOrEmpty(quote.BeginTimeLine) &&
                        string.IsNullOrEmpty(quote.EndTimeLine) && item.Length == 29)
                    {
                        quote.BeginTimeLine = item.Substring(0, 12);
                        quote.EndTimeLine = item.Substring(17, 12);
                    }
                    else
                    {
                        quote.QuoteLine += item + " ";
                    }
                }
                else
                {
                    quotes.Add(quote);
                    quote = new Quote();
                }
            }

            return quotes;
        }

        /// <summary>
        /// Return the subtitle as a Stream
        /// </summary>
        /// <param name="quotes">Lsit of quotes of the subtitle</param>
        /// <param name="newSubtitleName">A new name for the subtitle</param>
        /// <returns>Subtitle.srt</returns>
        public Stream WriteSubtitle(IList<Quote> quotes, string newSubtitleName)
        {
            using (StreamWriter sw = new StreamWriter(string.Format("C:/Temp/{0}", newSubtitleName)))
            {
                foreach (var quoteInfo in quotes)
                {
                    sw.WriteLine(quoteInfo.Index);
                    sw.WriteLine(string.Format("{0} --> {1}", quoteInfo.BeginTimeLine, quoteInfo.EndTimeLine));
                    sw.WriteLine(quoteInfo.QuoteLine);
                    sw.WriteLine("");
                }

                return sw.BaseStream;
            }
        }
    }
}

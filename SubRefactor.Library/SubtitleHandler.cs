﻿using System.Collections.Generic;
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

            using (StreamReader sr = new StreamReader(subtitle, Encoding.Default))
                allText = sr.ReadToEnd();

            /* 1 ^\d+$
             * 00:08:45,300 --> 00:08:46,038 ^([0-9]{2}:){2}[0-9]{2},[0-9]{3}\s-->\s([0-9]{2}:){2}[0-9]{2},[0-9]{3}\s*$
             */
            Regex indexRegex = new Regex(@"^\d+$");
            Regex timeRegex = new Regex(@"^([0-9]{2}:){2}[0-9]{2},[0-9]{3}\s-->\s([0-9]{2}:){2}[0-9]{2},[0-9]{3}\s*$");
            Regex integerRegex = new Regex(@"\d+");

            string[] quoteLines = Regex.Split(allText, Environment.NewLine + Environment.NewLine);
            foreach (string quoteLine in quoteLines)
            {
                if (string.IsNullOrEmpty(quoteLine))
                    continue;

                Quote quote = new Quote();

                string[] lines = Regex.Split(quoteLine, Environment.NewLine);
                foreach (string line in lines)
                {
                    if (indexRegex.IsMatch(line))
                    {
                        quote.Index = Convert.ToInt32(line);
                    }
                    else if (timeRegex.IsMatch(line))
                    {
                        MatchCollection matches = integerRegex.Matches(line);
                        if (matches.Count != 8)
                            throw new Exception("The selected file is invalid");

                        quote.BeginTimeLine = new TimeSpan(0, Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value),
                            Convert.ToInt32(matches[2].Value), Convert.ToInt32(matches[3].Value));
                        quote.EndTimeLine = new TimeSpan(0, Convert.ToInt32(matches[4].Value), Convert.ToInt32(matches[5].Value),
                            Convert.ToInt32(matches[6].Value), Convert.ToInt32(matches[7].Value));
                    }
                    else
                    {
                        quote.QuoteLine = line;
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
        /// <param name="newSubtitleName">A new name for the subtitle</param>
        /// <returns>Subtitle.srt</returns>
        public Stream WriteSubtitle(IList<Quote> quotes, string newSubtitleName)
        {
            using (StreamWriter sw = new StreamWriter(string.Format("C:/Temp/{0}", newSubtitleName), false, Encoding.Default))
            {
                foreach (Quote quoteInfo in quotes.OrderBy(q => q.Index))
                {
                    sw.WriteLine(quoteInfo.ToString());
                    sw.WriteLine();
                }

                sw.Flush();
                return sw.BaseStream;
            }
        }
    }
}

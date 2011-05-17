using System;
using System.Collections.Generic;
using System.IO;
using SubRefactor.Domain;

namespace SubRefactor.Library
{
    public class SynchronizationEngine
    {
        /// <summary>
        /// Sync the subtitle acording to the daley
        /// </summary>
        /// <param name="subtitle">Original subtitle stream</param>
        /// <param name="delay">TimeSpan chosen by the user</param>
        /// <param name="newSubtitleName">The new subtitle name chosen by the user</param>
        /// <returns>The new subtitle synchronized stream</returns>
        public IList<Quote> SyncSubtitle(IList<Quote> quotes, TimeSpan delay, bool negativeDelay)
        {
            foreach (var quote in quotes)
            {
                if (negativeDelay)
                {
                    quote.BeginTimeLine = TimeSpan.Parse(quote.BeginTimeLine).Subtract(delay).ToString();
                    quote.EndTimeLine = TimeSpan.Parse(quote.EndTimeLine).Subtract(delay).ToString();
                }
                else
                {
                    quote.BeginTimeLine = TimeSpan.Parse(quote.BeginTimeLine).Add(delay).ToString();
                    quote.EndTimeLine = TimeSpan.Parse(quote.EndTimeLine).Add(delay).ToString();
                }
            }

            return quotes;
        }
    }
}

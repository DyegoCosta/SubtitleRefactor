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
                    quote.BeginTimeLine = quote.BeginTimeLine.Subtract(delay);
                    quote.EndTimeLine = quote.EndTimeLine.Subtract(delay);
                }
                else
                {
                    quote.BeginTimeLine = quote.BeginTimeLine.Add(delay);
                    quote.EndTimeLine = quote.EndTimeLine.Add(delay);
                }
            }

            return quotes;
        }
    }
}

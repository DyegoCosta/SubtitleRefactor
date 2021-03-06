﻿using System;
using System.Collections.Generic;
using SubRefactor.Domain;
using System.Linq;

namespace SubRefactor.Library
{
    public class SynchronizationEngine
    {
        /// <summary>
        /// Sync the subtitle acording to the delay
        /// </summary>
        /// <param name="quotes">The quotes</param>
        /// <param name="delay">TimeSpan chosen by the user</param>
        /// <returns>The new subtitle synchronized stream</returns>
        public IList<Quote> SyncSubtitle(IList<Quote> quotes, TimeSpan delay)
        {
            foreach (var quote in quotes.OrderBy(q => q.Index))
            {
                var beginTime = quote.BeginTimeLine.Add(delay);
                if (beginTime.Ticks < 0)
                    throw new InvalidOperationException("The time generated by this amount of milliseconds cannot be negative. Increase the delay.");

                quote.BeginTimeLine = beginTime;
                quote.EndTimeLine = quote.EndTimeLine.Add(delay);
            }

            return quotes;
        }
    }
}

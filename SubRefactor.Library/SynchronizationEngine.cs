﻿using System;
using System.Collections.Generic;
using System.IO;
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
            foreach (Quote quote in quotes.OrderBy(q => q.Index))
            {
                //There's no need to call TimeSpan.Subtract since the "delay" is whether positive or negative, and adding negative number is the same as subtracting.
                TimeSpan beginTime = quote.BeginTimeLine.Add(delay);
                if (beginTime.Ticks < 0)
                    throw new InvalidOperationException("The time generated by this amount of milliseconds cannot be negative. Increase the delay.");

                quote.BeginTimeLine = beginTime;
                quote.EndTimeLine = quote.EndTimeLine.Add(delay);
            }

            return quotes;
        }
    }
}

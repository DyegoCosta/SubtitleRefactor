using System.Collections.Generic;
using System;
using System.Linq;

namespace SubRefactor.Domain
{
    public class Subtitle : ICloneable
    {
        public Subtitle(IList<Quote> quotes)
        {
            Quotes = quotes;
        }

        public string Name { get; set; }
        public string Release { get; set; }
        public IList<Quote> Quotes { get; set; }
        
        public Subtitle Clone()
        {
            IList<Quote> quotesCopy = Quotes.ToList();
            return new Subtitle(quotesCopy) {Name = Name, Release = Release};            
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }
    }
}

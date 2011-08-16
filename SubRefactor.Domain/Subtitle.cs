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

        public object Clone()
        {
            IList<Quote> quotesCopy = Quotes.ToList();
            return new Subtitle(quotesCopy) { Name = this.Name };
        }
    }
}

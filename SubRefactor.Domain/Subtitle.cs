using System.Collections.Generic;
using System;
using System.Linq;

namespace SubRefactor.Domain
{
    public class Subtitle
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
            var quotesCopy = Quotes.Select(quote => quote.Clone()).ToList();

            return new Subtitle(quotesCopy) { Name = Name, Release = Release };
        }
    }
}

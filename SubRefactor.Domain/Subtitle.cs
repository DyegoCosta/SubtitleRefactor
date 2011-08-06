using System.Collections.Generic;

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
    }
}

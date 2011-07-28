using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubRefactor.Domain
{
    public class Quote
    {
        #region Properties

        public string Index { get; set; }
        public string BeginTimeLine { get; set; }
        public string EndTimeLine { get; set; }
        public string QuoteLine { get; set; }
        
        #endregion

        public Quote(string index, string beginTimeLine, string endTimeLine, string quote)
        {
            this.Index = index;
            this.BeginTimeLine = beginTimeLine;
            this.EndTimeLine = endTimeLine;
            this.QuoteLine = quote;   
        }

        public Quote()
        {

        }
    }
}

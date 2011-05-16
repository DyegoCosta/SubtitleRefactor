using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubRefactor.Domain
{
    public class Quote
    {
        #region Properties
        
        public string Index;
        public string BeginTimeLine;
        public string EndTimeLine;
        public string QuoteLine;
        
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

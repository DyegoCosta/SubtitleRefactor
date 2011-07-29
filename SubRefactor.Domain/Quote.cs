using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubRefactor.Domain
{
    public class Quote
    {
        #region Properties

        public int Index { get; set; }
        public TimeSpan BeginTimeLine { get; set; }
        public TimeSpan EndTimeLine { get; set; }
        public string QuoteLine { get; set; }

        #endregion

        public Quote(int index, TimeSpan beginTimeLine, TimeSpan endTimeLine, string quote)
        {
            this.Index = index;
            this.BeginTimeLine = beginTimeLine;
            this.EndTimeLine = endTimeLine;
            this.QuoteLine = quote;
        }

        public Quote()
        {

        }

        public override string ToString()
        {
            StringBuilder sbQuote = new StringBuilder();
            sbQuote.AppendLine(this.Index.ToString());
            sbQuote.AppendFormat("{0} --> {1}", this.BeginTimeLine.ToString(@"hh\:mm\:ss\,fff"), this.EndTimeLine.ToString(@"hh\:mm\:ss\,fff"));
            sbQuote.AppendLine();
            sbQuote.Append(this.QuoteLine);

            return sbQuote.ToString();
        }
    }
}

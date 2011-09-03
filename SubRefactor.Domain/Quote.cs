using System;
using System.Text;

namespace SubRefactor.Domain
{
    public class Quote : ICloneable
    {
        public int Index { get; set; }
        public TimeSpan BeginTimeLine { get; set; }
        public TimeSpan EndTimeLine { get; set; }
        public string QuoteLine { get; set; }

        public Quote(int index, TimeSpan beginTimeLine, TimeSpan endTimeLine, string quote)
        {
            Index = index;
            BeginTimeLine = beginTimeLine;
            EndTimeLine = endTimeLine;
            QuoteLine = quote;
        }

        public Quote() { }

        public override string ToString()
        {
            var sbQuote = new StringBuilder();
            sbQuote.AppendLine(this.Index.ToString());
            sbQuote.AppendFormat("{0} --> {1}", this.BeginTimeLine.ToString(@"hh\:mm\:ss\,fff"), this.EndTimeLine.ToString(@"hh\:mm\:ss\,fff"));
            sbQuote.AppendLine();
            sbQuote.Append(QuoteLine);

            return sbQuote.ToString();
        }

        public Quote Clone()
        {
            return new Quote(Index, BeginTimeLine, EndTimeLine, QuoteLine);
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

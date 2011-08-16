using System.Collections.Generic;


namespace LinqBits
{
    public class SequenceWithSeparator<TItem>
    {
        public SequenceWithSeparator(IEnumerable<TItem> sequence,string middle)
            : this(sequence,string.Empty, middle, string.Empty)
        {
        }

        public SequenceWithSeparator(IEnumerable<TItem> sequence, string start, string middle) : this(sequence,start,  middle, string.Empty)
        {
        }

        public SequenceWithSeparator(IEnumerable<TItem> sequence,string start, string middle, string end)
        {
            Sequence = sequence;
            Start = start;
            Middle = middle;
            End = end;
        }
        public IEnumerable<TItem> Sequence  { get; set; }
        public string Start { get; set; }
        public string Middle { get; set; }
        public string End { get; set; }
    }
}

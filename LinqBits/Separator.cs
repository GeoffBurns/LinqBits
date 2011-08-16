
namespace LinqBits
{
    public class Separator
    {
        public Separator(string middle)
            : this(string.Empty, middle, string.Empty)
        {
        }

        public Separator(string start, string middle) : this(start,  middle, string.Empty)
        {
        }

        public Separator(string start, string middle, string end)
        {
            Start = start;
            Middle = middle;
            End = end;
        }

        public string Start { get; set; }
        public string Middle { get; set; }
        public string End { get; set; }
    }
}

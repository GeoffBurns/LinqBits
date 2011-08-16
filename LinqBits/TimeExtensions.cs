using System;

namespace LinqBits
{
    public static class TimeExtensions
    {
        public static TimeSpan Seconds(this int sec)
        {
            return new TimeSpan(0, 0, sec);
        }
 
        public static TimeSpan Minutes(this int min)
            {
                return new TimeSpan(0, min, 0);
            }
        public static TimeSpan Hours(this int hr)
        {
            return new TimeSpan(hr, 0, 0);
        }

        public static TimeSpan Days(this int dy)
        {
            return new TimeSpan(dy, 0, 0, 0);
        }
    }
}

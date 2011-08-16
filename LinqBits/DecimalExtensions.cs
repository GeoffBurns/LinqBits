using System;

namespace LinqBits
{
    public static class DecimalExtensions
    {
        /// <summary> 
        /// Checks if string has value. Trims the text before checking for it
        /// </summary> 
        public static string FormattedAsBalance(this decimal val)
        {
            var descimalFormatted = String.Format("{0:C}", Math.Abs(val));
            if (val < 0)
                descimalFormatted += " CR";

            return descimalFormatted;
        }
    }
}

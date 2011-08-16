using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqBits
{
    public static class SeparatorExtension
    {
        /// <summary>
        /// Join a sequence of object using convertToString
        /// </summary>
        public static SequenceWithSeparator<T> WithSeparator<T>(this IEnumerable<T> source,
                                                  string start, string middle, string end)
        {
            return new SequenceWithSeparator<T>(source, start, middle, end);
        }

        public static SequenceWithSeparator<T> WithSeparator<T>(this IEnumerable<T> source,
                                          string start, string middle)
        {
            return new SequenceWithSeparator<T>(source, start, middle);
        }
        public static SequenceWithSeparator<T> WithSeparator<T>(this IEnumerable<T> source, string middle)
        {
            return new SequenceWithSeparator<T>(source,  middle);
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this SequenceWithSeparator<T> sequenceWithSeparator,
                                                    Action<T, StringBuilder> addToStringBuilder)
        {
            return new StringBuilder()
                   .StringBuilderJoin(sequenceWithSeparator.Sequence, sequenceWithSeparator.Start, addToStringBuilder, sequenceWithSeparator.Middle, sequenceWithSeparator.End)
                   .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this SequenceWithSeparator<T> sequenceWithSeparator,
                                                    Func<T, string> convertToString)
        {
            return new StringBuilder()
                   .StringBuilderJoin(sequenceWithSeparator.Sequence, sequenceWithSeparator.Start, convertToString, sequenceWithSeparator.Middle, sequenceWithSeparator.End)
                   .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this SequenceWithSeparator<T> sequenceWithSeparator)
        {
            return new StringBuilder()
                   .StringBuilderJoin(sequenceWithSeparator.Sequence, sequenceWithSeparator.Start, item=>item.ToString(), sequenceWithSeparator.Middle, sequenceWithSeparator.End)
                   .ToString();
        }
    }
}

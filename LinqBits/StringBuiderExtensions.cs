using System;
using System.Collections.Generic;
using System.Text;

namespace LinqBits
{
    public static class StringBuiderExtensions
    {
        /// <summary>
        /// Join sequence of strings
        /// </summary>
        public static StringBuilder StringBuilderJoin(this StringBuilder accumulator, IEnumerable<string> source )
        {
            foreach (var s in source)
                accumulator.Append(s);
            return accumulator;
        }
        /// <summary>
        /// Join a sequence of object using addToStringBuilder
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator, IEnumerable<T> source,
                                                  Action<T, StringBuilder> addToStringBuilder)
        {
            foreach (var item in source)
               addToStringBuilder(item,accumulator);
            return accumulator;
        }
        /// <summary>
        /// Join a sequence of object using convertToString
        /// </summary>

        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator, IEnumerable<T> source,
                                                  Func<T, string> convertToString)
        {
            foreach (var item in source)
                accumulator.Append(convertToString(item));
            return accumulator;
        }
        /// <summary>
        /// Join sequence of object using ToString methed
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source, StringBuilder accumulator) 
        {
            return accumulator
                       .StringBuilderJoin(  source,
                                            item => item.ToString());
        }
        /// <summary>
        /// Join sequence of object using ToString methed
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source)
        {
            return source.ToJoinedStringBuilder(new StringBuilder());
        }

        public static StringBuilder StringBuilderJoin(this StringBuilder accumulator, IEnumerable<string> source, string separator)
        {

            var isNotFirst = false;
            foreach (var s in source)
            {
                if (isNotFirst)
                    accumulator.Append(separator);
                accumulator.Append(s);
                isNotFirst = true;
            }
            return accumulator;
        }
        /// <summary>
        /// Join a sequence of objects using ToString and a separator
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source, StringBuilder accumulator, string separator)
        {
            return accumulator.StringBuilderJoin(source, item => item.ToString(), separator);
        }
        /// <summary>
        /// Join a sequence of objects using ToString and a separator
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source,  string separator)
        {
            return source.ToJoinedStringBuilder(new StringBuilder(),separator);
        }
        /// <summary>
        /// Join a sequence of object using addToStringBuilder
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator, IEnumerable<T> source,
                                                                Action<T, StringBuilder> addToStringBuilder, 
                                                                string separator)
        {
            var isNotFirst = false;
            foreach (var item in source)
            {
                if (isNotFirst)
                    accumulator.Append(separator);
                addToStringBuilder(item, accumulator);
                isNotFirst = true;
            }
            return accumulator;
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator, 
                                                            IEnumerable<T> source,
                                                            Func<T, string> convertToString, 
                                                            string separator)
        {
            var isNotFirst = false;
            foreach (var item in source)
            {
                if (isNotFirst)
                    accumulator.Append(separator);
                accumulator.Append(convertToString(item));
                isNotFirst = true;
            }
            return accumulator;
      
        }
        /// <summary>
        /// Join a sequence of object using addToStringBuilder
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator,
                                                                IEnumerable<T> source,
                                                               string start,
                                                               Action<T, StringBuilder> addToStringBuilder,
                                                               string separator)
        {
            return accumulator.Append(start)
                  .StringBuilderJoin(source, addToStringBuilder, separator);
        }
        /// <summary>
        /// Join a sequence of objects using convertToString, prefix and a separator
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(
                                     this StringBuilder accumulator,
                                     IEnumerable<T> source,
                                     string start,
                                     Func<T, string> convertToString,
                                     string separator)
        {
            return accumulator.Append(start)
                .StringBuilderJoin(source, convertToString, separator);
        }
        /// <summary>
        /// Join a sequence of objects using ToString, prefix and a separator
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source,
                                     StringBuilder accumulator,
                                     string start,
                                     string separator)
        {
            return accumulator.Append(start).StringBuilderJoin(source, item => item.ToString(), separator);
        }
        /// <summary>
        /// Join a sequence of objects using ToString, prefix and a separator
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source,         
                                     string start,
                                     string separator)
        {
            return source.ToJoinedStringBuilder(new StringBuilder(), start, separator);
        }
        /// <summary>
        /// Join a sequence of object using addToStringBuilder
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator, 
                                                                IEnumerable<T> source,
                                                               string start,
                                                               Action<T, StringBuilder> addToStringBuilder,
                                                               string separator,
                                                               string finish)
        {
            return accumulator.Append(start)
                  .StringBuilderJoin(source, addToStringBuilder, separator)
                  .Append(finish);
        }
        /// <summary>
        /// Join a sequence of objects using ToString, a prefix, a separator and a suffix
        /// </summary>
        public static StringBuilder StringBuilderJoin<T>(this StringBuilder accumulator, 
                                        IEnumerable<T> source,
                                       string start,
                                       Func<T, string> convertToString,
                                       string separator,
                                       string finish)
        {
            return accumulator.Append(start)
                .StringBuilderJoin(source, convertToString, separator)
                .Append(finish);
        }
        /// <summary>
        /// Join a sequence of objects using ToString, a prefix, a separator and a suffix
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source,
                            StringBuilder accumulator,
                             string start,
                             string separator,
                             string finish)
        {
            return accumulator.StringBuilderJoin(source, start,item => item.ToString(), separator, finish);
        }
        /// <summary>
        /// Join a sequence of objects using ToString, prefix and a separator
        /// </summary>
        public static StringBuilder ToJoinedStringBuilder<T>(this IEnumerable<T> source,
                                                             string start,
                                                             string separator,
                                                             string finish)
        {
            return source.ToJoinedStringBuilder(new StringBuilder(), start, separator, finish);
        }
    }
}


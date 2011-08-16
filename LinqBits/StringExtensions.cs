using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LinqBits
{
    public static class StringExtensions
    {
        /// <summary> 
        /// Checks if string has value. Trims the text before checking for it
        /// </summary> 
        public static bool HasValue(this string str)
        {
            return (!string.IsNullOrEmpty(str) && (str.Trim().Length > 0));
        }

        public static string ConvertToProperCase(string stringToConvert)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(stringToConvert.ToLower());
        }
        /// <summary>
        /// Join sequence of strings
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StringJoin(this IEnumerable<string> source)
        {
            return new StringBuilder()
                        .StringBuilderJoin(source)
                        .ToString();
        }
        /// <summary>
        /// Join a sequence of object using convertToString
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                                  Func<T, string> convertToString)
        {
            return new StringBuilder()
                      .StringBuilderJoin(source, convertToString)
                      .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                                    Action<T, StringBuilder> addToStringBuilder)
        {
            return new StringBuilder()
                   .StringBuilderJoin(source, addToStringBuilder)
                   .ToString();
        }
        /// <summary>
        /// Join sequence of object using ToString methed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJoinedString<T>(this IEnumerable<T> source)
        {
            return source.
                          ToJoinedStringBuilder()
                          .ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string StringJoin(this IEnumerable<string> source, string separator)
        {
            return new StringBuilder()
                               .StringBuilderJoin(source, separator)
                               .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using ToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source, string separator)
        {
            return source.
                          ToJoinedStringBuilder(separator)
                          .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                                  Func<T, string> convertToString, string separator)
        {
            return new StringBuilder()
                   .StringBuilderJoin(source, convertToString, separator)
                   .ToString();
        }    
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(     this IEnumerable<T> source,
                                                    Action<T, StringBuilder> addToStringBuilder, 
                                                    string separator)
        {
            return new StringBuilder()
                   .StringBuilderJoin(source, addToStringBuilder, separator)
                   .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using convertToString, prefix and a separator
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                     string start,
                                     Func<T, string> convertToString,
                                     string separator)
        {
            return new StringBuilder()
                        .StringBuilderJoin(source, start, convertToString, separator)
                        .ToString();
        }

        /// <summary>
        /// Join a sequence of objects using ToString, prefix and a separator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                     string start,
                                     string separator)
        {
            return new StringBuilder()
                          .StringBuilderJoin(source, start, item => item.ToString(), separator)
                          .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using ToString, a prefix, a separator and a suffix
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                       string start,
                                       Func<T, string> convertToString,
                                       string separator,
                                       string finish)
        {
            return new StringBuilder()
                          .StringBuilderJoin(source, start, convertToString, separator, finish)
                          .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using convertToString and a separator
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                                   string start,
                                                    Action<T, StringBuilder> addToStringBuilder,
                                                    string separator,
                                                    string finish)
        {
            return new StringBuilder()
                   .StringBuilderJoin(source, start, addToStringBuilder, separator, finish)
                   .ToString();
        }
        /// <summary>
        /// Join a sequence of objects using ToString, a prefix, a separator and a suffix
        /// </summary>
        public static string ToJoinedString<T>(this IEnumerable<T> source,
                                       string start,
                                       string separator,
                                       string finish)
        {
            bool isNotFirst = false;

            var sb = new StringBuilder();
            sb.Append(start);
            foreach (T item in source)
            {
                if (isNotFirst)
                    sb.Append(separator);
                sb.Append(item.ToString());
                isNotFirst = true;
            }

            sb.Append(finish);
            return sb.ToString();
        }
    }

}

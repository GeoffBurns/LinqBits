using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBits
{
    public static class LinqExtentions
    {
        /// <summary>
        /// No item in Collection passes test
        /// </summary>
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource,bool> test) 
        {
            return !source.Any(test);
        }
        /// <summary>
        /// Collection is Empty
        /// </summary>
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            return !source.Any();
        }
        /// <summary>
        /// Returns only the results where the transform was successful (i.e. produced a result with a value)
        /// </summary>
        public static IEnumerable<TResult> SelectValues<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult?> transform) where TResult : struct
        {
            return from item in source select transform(item) into result where result.HasValue select result.Value;
        }
        /// <summary>
        ///  Returns only the results where the transform was successful (i.e. produced a Reference Object that exists [is non-null])
        /// </summary>
        public static IEnumerable<TResult> SelectExisting<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> transform) where TResult : class
        {
            return from item in source select transform(item) into result where result != null select result;
        }
        /// <summary>
        /// Returns only the items that have a value
        /// </summary>
        public static IEnumerable<TSource> SelectValues<TSource>(this IEnumerable<TSource?> source) where TSource : struct
        {
            return from item in source where item.HasValue select item.Value;
        }

        /// <summary>
        /// Returns only the Reference Objects that are non-null
        /// </summary> 
        public static IEnumerable<TSource> SelectExisting<TSource>(this IEnumerable<TSource> source) where TSource : class
        {
            return from item in source  where item != null select item;
        }

        public static IEnumerable<T> ToSequence<T>(this T item)
        {
            yield return item;
        }

        public static IEnumerable<T> ToSequence<T>(this T? item) where T: struct
        {
            return item.HasValue ? item.Value.ToSequence() : Enumerable.Empty<T>();
        }

        public static List<T> ToSingleItemList<T>(this T item)
        {
            return new List<T> { item };
        }

        public static List<T> ToList<T>(this T? item) where T : struct
        {
            return item.HasValue ? item.Value.ToSingleItemList() : new List<T>();
        }

        public static TResult? SelectMany<T, TResult>(this T? source, Func<T, TResult?> selector) 
                    where T : struct 
                    where TResult : struct
        {
            return source.HasValue ? selector(source.Value) : null;
        }

        public static TResult SelectMany<T, TResult>(this T? source, Func<T, TResult> selector)
            where T : struct
            where TResult : class
        {
            return source.HasValue ? selector(source.Value) : null;
        }
        public static T? FirstValue<T>(this IEnumerable<T> source) where T : struct
        {
            // let's just take the first one)
            foreach (T item in source) return item;

            return null;
        }

        public static T? LastValue<T>(this IEnumerable<T> source) where T : struct
        {
            if (source.None())
                return null;

            return source.Last();
        }
    }
}

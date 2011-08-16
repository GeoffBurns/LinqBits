using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBits
{
    public static class SetExtensions
    {
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        {
            return new HashSet<TSource>(source);
        }
        public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> transform)
        {
            return new HashSet<TResult>(source.Select(transform));
        }
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return new HashSet<TSource>(source, comparer);
        }
    }
}

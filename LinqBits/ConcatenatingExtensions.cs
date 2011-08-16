using System.Collections.Generic;
using System.Linq;

namespace LinqBits
{
    public static class ConcatenatingExtensions
    {

         public static IEnumerable<T> AndThen<T>(this T head, IEnumerable<T> tail)
        {
            tail.ThrowIfNull("tail");
            return tail.AddAfter(head);
        }

            public static IEnumerable<T> AndThen<T>(this IEnumerable<T> head, T tail)
        {
            head.ThrowIfNull("head");
            return head.Concat(tail.ToSequence());
        }
        public static IEnumerable<T> AndThen<T>(this IEnumerable<T> head, IEnumerable<T> tail)
        {
            head.ThrowIfNull("head");
            tail.ThrowIfNull("tail");
            return head.Concat(tail);
        }
        public static IEnumerable<T> AndThen<T>(this T? head, IEnumerable<T> tail) where T : struct
        {
            return tail.AddAfter(head);
        }

           public static IEnumerable<T> AndThen<T>(this IEnumerable<T> head, T? tail) where T : struct
        {
            return head.Concat(tail.ToSequence());
        }

        public static IEnumerable<T> AndThenIfExists<T>(this T head, IEnumerable<T> tail) where T : class 
        {
            return tail.PrependIfExist(head);
        }

        public static IEnumerable<T> AndThenIfExist<T>(this IEnumerable<T> head, T tail) where T : class 
        {
            return tail==null ? head : head.Concat(tail.ToSequence());
        }

        public static IEnumerable<T> AndThenIfExist<T>(this T head, T tail) where T : class
        {
            return tail == null
                ? (head == null
                      ? Enumerable.Empty<T>()
                      : head.ToSequence())
                : (head == null
                      ? tail.ToSequence()
                      : new[] { head, tail });
        }

        public static IEnumerable<TSource> PrependIfExist<TSource>(this IEnumerable<TSource> source, TSource value) where TSource : class 
        {
            return value==null ? source : value.ToSequence().Concat(source);
        }


        public static IEnumerable<TSource> AddAfter<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            source.ThrowIfNull("source");
            return value.ToSequence().Concat(source);
        }

        public static IEnumerable<TSource> AddAfter<TSource>(this IEnumerable<TSource> source, TSource? value) where TSource : struct
        {
            return value.ToSequence().Concat(source);
        }
    }
}

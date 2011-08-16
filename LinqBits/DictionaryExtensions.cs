using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBits
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// If you have a sequence of KeyValuePairs then just use the existing Key and Value when creating the dictionary
        /// </summary>

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            return source.ToDictionary(s => s.Key, s => s.Value);
        }
        /// <summary>
        /// If you have a KeyValuePair then just use the existing Key and Value when adding to the dictionary
        /// </summary>
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> destination, KeyValuePair<TKey, TValue> kvp)
        {
            destination.Add(kvp.Key, kvp.Value);
        }

        /// <summary>
        /// If you have a sequence of KeyValuePairs then just use the existing Key and Value when creating the dictionary
        /// </summary>
        public static Dictionary<TKey, TValue> ToDistinctDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (var keyValuePair in source)
            {
                result.AddDistinct(keyValuePair);
            }
            return result;
        }

        /// <summary>
        /// If you have a sequence of KeyValuePairs then just use the existing Key and Value when creating the dictionary
        /// </summary>
        public static Dictionary<TKey, TValue> ToDistinctDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (var item in source)
            {
                result.AddDistinct(keySelector(item), valueSelector(item));
            }
            return result;
        }
        /// <summary>
        /// If you have a KeyValuePair then check for a existing Key  when adding to the dictionary
        /// </summary>
        public static void AddDistinct<TKey, TValue>(this IDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> kvp)
        {
            if (!source.ContainsKey(kvp.Key))
                source.Add(kvp.Key, kvp.Value);
        }
        /// <summary>
        /// If you have a collection KeyValuePairs then check for a existing Keys  when adding to the dictionary
        /// </summary>
        public static void AddDistinctRange<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<KeyValuePair<TKey, TValue>> kvps)
        {
            foreach (var keyValuePair in kvps)
            {
                source.AddDistinct(keyValuePair);
            }
        }
        /// <summary>
        /// If you have a collection of item then check for a existing Keys  when adding to the dictionary
        /// </summary>
        public static void AddDistinctRange<TSource, TKey, TValue>(this IDictionary<TKey, TValue> destination, IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
        {
            foreach (var item in source)
            {
                destination.AddDistinct(keySelector(item), valueSelector(item));
            }
        }
        /// <summary>
        /// a collection KeyValuePairs then add to the dictionary
        /// </summary>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> destination, IEnumerable<KeyValuePair<TKey, TValue>> kvps)
        {
            foreach (var keyValuePair in kvps)
            {
                destination.Add(keyValuePair);
            }
        }
        /// <summary>
        /// add sequence of items to a Collection
        /// </summary>
        public static void AddRange<TValue>(this ICollection<TValue> destination, IEnumerable<TValue> source)
        {
            foreach (var item in source)
            {
                destination.Add(item);
            }
        }
        /// <summary>
        /// If you have a Key and Value then check for a existing Key  when adding to the dictionary
        /// </summary>
        public static void AddDistinct<TKey, TValue>(this IDictionary<TKey, TValue> destination, TKey k, TValue v)
        {
            if (!destination.ContainsKey(k))
                destination.Add(k, v);
        }
    }
}

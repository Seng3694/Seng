using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(
               this IDictionary<TKey, TValue> dictionary,
               TKey key,
               TValue value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);

            return dictionary[key];
        }

        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> valueFactory)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, valueFactory());

            return dictionary[key];
        }

        public static void AddOrSet<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }

        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            else
                return default(TValue);
        }
    }
}

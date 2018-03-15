using System.Collections.Generic;

namespace Seng.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T item)
        {
            foreach (var element in enumerable)
                yield return element;
            yield return item;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> enumerable, T item)
        {
            yield return item;
            foreach (var element in enumerable)
                yield return element;
        }
    }
}

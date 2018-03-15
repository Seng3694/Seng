using System;

namespace Seng.Extensions
{
    public static class ArrayExtensions
    {
        public static void QuickSort<T>(this T[] array)
            where T : IComparable<T>, IComparable
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort<T>(this T[] array, int start, int end)
            where T : IComparable<T>, IComparable
        {
            if (start >= end) return;

            var value = array[start];
            int i = start;
            int j = end;

            while (i < j)
            {
                while (i < j && array[j].CompareTo(value) > 0) j--;

                array[i] = array[j];

                while (i < j && array[i].CompareTo(value) < 0) i++;

                array[j] = array[i];
            }

            array[i] = value;
            QuickSort(array, start, i - 1);
            QuickSort(array, i + 1, end);
        }
    }
}

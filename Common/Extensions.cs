using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this IList<T> arr, int left, int right)
        {
            var tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
        }
    }
}
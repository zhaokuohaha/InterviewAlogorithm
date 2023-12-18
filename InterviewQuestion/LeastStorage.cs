using System;
using System.Text.Json;

namespace ConsoleApplication
{
    public class LeastStorage : ITemplate
    {
        public void print()
        {
            Solve(new int[]{1, 1, 1, 3}, 4);
            Solve(new int[]{2, 3, 6, 7}, 4);
            Solve(new int[]{1, 1, 1, 1}, 4);
        }

        private int best = int.MaxValue;
        private int[] rest;

        private void Solve(int[] arr, int num)
        {
            
            Prepare(arr);
            System.Console.WriteLine($"Arr: {JsonSerializer.Serialize(arr)}");
            System.Console.WriteLine($"Rest: {JsonSerializer.Serialize(rest)}");
            Search(arr, 0, num, 0);
            System.Console.WriteLine($"Best: {best}");
        }

        private void Prepare(int[] arr)
        {
            best = int.MaxValue;
            var sum = 0;
            rest = new int[arr.Length];
            for(var i = arr.Length -1; i >= 0; i--)
            {
                rest[i] = sum;
                sum += arr[i];
            }
        }

        private void Search(int[] arr, int index, int num, int used)
        {
            if (num <= 0)
            {
                if (used < best)
                {
                    best = used;
                }

                return;
            }

            // 优化1：如果已经使用空间大于已经找到的解， 结束
            if (used > best)
            {
                return;
            }

            if(index >= arr.Length)
            {
                return;
            }

            // 优化2 优先尝试不用第 i 块空间， 但是要求剩下的空间足够
            if(rest[index] >= num)
            {
                Search(arr, index+1, num, used);
            }

            // 使用第 i 块空间
            Search(arr, index+1, num-arr[index], used+arr[index]);
        }
    }
}
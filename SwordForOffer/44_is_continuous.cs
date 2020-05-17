using System;
using System.Linq;

namespace ConsoleApplication
{
    public class IsContinuous : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(CheckContinuous(new int[] { 1, 2, 3, 5, 6 }));
            System.Console.WriteLine(CheckContinuous(new int[] { 1, 2, 0, 5, 6 }));
            System.Console.WriteLine(CheckContinuous(new int[] { 1, 0, 3, 5, 6 }));
        }


        private bool CheckContinuous(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return false;

            Array.Sort(nums);

            var zeros = nums.Count(n => n == 0);
            for (var i = zeros; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] == nums[i])
                    return false;
                if (nums[i + 1] - nums[i] != 1)
                    zeros--;
            }

            return zeros >= 0;
        }
    }
}
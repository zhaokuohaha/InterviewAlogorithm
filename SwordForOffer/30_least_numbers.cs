using System;
using System.Linq;

namespace ConsoleApplication
{
    public class LeastNumbers : ITemplate
    {
        public void print()
        {
            var t1 = new int[][]{
                new int[]{1,3,4,8,5,23},
                new int[]{1,2,2},
                new int[]{1,1},
                new int[]{1,1,22,3,4}
            };
            var t2 = new[] { 3, 2, 1, 4 };

            for (var i = 0; i < t2.Length; i++)
            {
                var str = $"({string.Join(',', t1[i])}) : Least({t2[i]})";
                var res = $"({string.Join(',', GetLastNumbersByPartion(t1[i], t2[i]))})";
                System.Console.WriteLine($"{str} => {res}");
            }
        }

        // 基于Partition函数, 修改原有数组, 将比第k个数字小的数移动到数组的左边
        // Partition 函数虽多次调用,但是实际上不会重复处理数据, 所以时间复杂度 O(n)
        private int[] GetLastNumbersByPartion(int[] arr, int k)
        {
            if (arr == null || arr.Length < k || k <= 0)
                return null;

            int start = 0, end = arr.Length - 1;
            var index = Partition(arr, start, end);
            while (index != k - 1)
            {
                if (index > k - 1)
                {
                    index = Partition(arr, start, index - 1);
                }
                else
                {
                    index = Partition(arr, index + 1, end);
                }
            }
            return arr.Take(k).ToArray();
        }

        // Partition 函数: 快排的基本思想, 以某个数(arr[index] 记为 ak)为基准(本例取最左数)
        // 大于等于 ak 的数放在其右边, 小于等于ak的数放在左边 (即遍历到等于的数不交换)
        // 返回ak的位置, 即最终的index
        private int Partition(int[] arr, int left, int right)
        {
            var index = left;
            while (left < right)
            {
                // 右边部分
                while (index < right && arr[right] >= arr[index])
                    right--;
                if (index < right)
                {
                    arr.Swap(left, right);
                    index = right;
                }

                // 左边部分
                while (left < index && arr[left] <= arr[index])
                    left++;
                if (left < index)
                {
                    arr.Swap(left, right);
                    index = left;
                }
            }
            return index;
        }


        // 解法二: 使用一个最大堆来保存最小的K个数,
        // 遍历一遍数组, 每次将小于堆顶的数据替换出去, 保证堆中的数据始终是最小的
        // 遍历时间 O(n), 没遍历一个数都有可能替换堆, 重新构造最大堆时间 O(logk) 所以时间复杂度是 O(nlogk)
        // 为了保证堆的平衡, 应该用红黑树来实现最大堆, 否则时间复杂度会变成O(nk)
        // 红黑树实现比较复杂, 本例不实现, 如果有线程红黑树, 实现逻辑比较简单, 下面为伪码:
        private int[] GetLastNumbersByRBT(int[] arr, int k)
        {
            // var rbt = new RBT();
            // foreach(var num in arr){
            //     if(num < rbt.root){
            //         rbt.root = num;
            //         rbt.ReBuild();
            //     }
            // }
            // return rbt.ToArray();
            throw new NotImplementedException();
        }
    }
}
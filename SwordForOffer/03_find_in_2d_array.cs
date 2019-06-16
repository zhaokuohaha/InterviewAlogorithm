// 在一个从左到右从上到下有序递增的二维数组中查找某个给定的值是否存在

using System;

namespace ConsoleApplication {
    public class FindIn2dArray : ITemplate
    {
        public void print()
        {
            int[,] array = new int[,] {
                {1,2,3,10},
                {4,5,6,11},
                {7,8,9,12}
            };
           System.Console.WriteLine(Find(array, 8));
           System.Console.WriteLine(Find(array, 0));
           System.Console.WriteLine(Find(array, 13));
        }

        //从右上角开始找， 如果 val > num 说明 num 只能在 val 的 左边 （右边都大于val, 而上方已经遍历过） --> y --
        // 否则 num 只能在 val 下边, 同理， 上边小于val, 而右边已经遍历过）
        // 返回 元素的位置（或出界的文职）
        public (int x, int y) Find(int[,] arr, int num){
            var x = 0;
            var y = arr.GetLength(1) -1;
            
            while(x < arr.GetLength(0) && y >= 0){
                var val = arr[x, y];
                if (val == num)
                    break;
                if(val > num)
                    y --;
                else
                    x ++;
            }
            return (x, y);
        }
    }
}
/**
红包分配: 输入总金额和红包个数, 输出每个红包的金额
要求: 每个红包金额随机, 红包总金额不能出错
方法: 隔板法
 */

 using System;
 using System.Collections.Generic;
namespace ConsoleApplication
{
    public class RedPacketsdistributeClass
    {
        public void print(){
          var values = this.RedPacketsdistribute(100, 10);
          Console.WriteLine(string.Join(" , ", values));
          
          double sum = 0;
          foreach(double value in values)
            sum += value;
          Console.WriteLine("Total: " + sum);
        }

        public double[] RedPacketsdistribute(double total, int count){
          // 先保留一个最小值, 这样如果隔板重复, 就避免红包等于零的情况
            var minVal = 0.01;
            total -= (minVal * count);
          // 放置 count-1个隔板, 并且将最小值和最大值作为两个隔板
            var clapboards = new List<double>(){0,total};
            var random = new Random();
            for(int i=0; i<count-1; i++){
              var next = Math.Round(random.NextDouble() * total,2);
              clapboards.Add(next);
            }
            clapboards.Sort();
          // 将各个隔板间的长度作为红包值
            var res = new double[count];
            var index = 0;
            for(int i=0; i<count; i++){
              res[index++] = Math.Round(clapboards[i+1]-clapboards[i]+minVal,2); // 再次确认精度
            }
            return res;
        }
    }
}
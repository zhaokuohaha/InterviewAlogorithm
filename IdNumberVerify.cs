using System;
// 根据 http://blog.jobbole.com/111556/ 写的身份证号验证， 但是好像不对啊！！！
namespace ConsoleApplication
{
    public class IdNumberVerifyClass
    {
        int []baseKey = {7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2};
        char []veriKey = {'1','0','X','9','8','7','6','5','4','3','2'};

        public void print(){
            string [] test = {
                "输入您的身份证号",
            };
            Console.WriteLine(IdNumberVerify(test[0]));
        }

        public bool IdNumberVerify(string number){
            if (number.Length != 18)
                return false;
            var sum = 0;
            for(int i=0; i<17; i++)
            {
                int indexVal = (int)number[i];
                sum += (indexVal * baseKey[i]);
            }

            var res = sum % 11;
            if(veriKey[res] != number[17]){
                Console.WriteLine($"res = {res}, the correct number should be {veriKey[res]}, but it's {number[17]} in your input");
                return false;
            }
            else
                return true;
        }
    }
}
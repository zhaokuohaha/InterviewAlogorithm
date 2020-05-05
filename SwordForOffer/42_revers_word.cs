using System;

namespace ConsoleApplication{
    public class ReverseWord : ITemplate {
        public void print(){
            System.Console.WriteLine(ReverseSentence("hello this reverse sentence"));
            System.Console.WriteLine("good");
            System.Console.WriteLine("");

            System.Console.WriteLine(LeftRotate("123456789", 3));
            System.Console.WriteLine(LeftRotate("123456789", 9));
        }


        private string ReverseSentence(string s){
            var arr = s.ToCharArray();
            int start = 0, end = arr.Length -1;
            Reverse(arr, start, end);

            int index = 0;
            while(index <= end){
                while(index <= end && arr[index] == ' ') index ++;
                int left = index;

                while(index <= end && arr[index] != ' ') index ++;
                int right = index - 1;

                Reverse(arr, left, right);
            }

            return new string(arr);
        }


        private string LeftRotate(string s, int n){
            if(s == null || s.Length <= n || n == 0)
              return s;
            
            var arr = s.ToCharArray();
            Reverse(arr, 0, n-1);
            Reverse(arr, n, arr.Length -1);
            Reverse(arr, 0, arr.Length -1);

            return new string(arr);
        }

        private void Reverse(char[] s, int left, int right){
            if(s == null || s.Length <= right || left < 0)
                return;
            
            char temp;
            while(left < right){
               temp = s[left];
               s[left++] = s[right];
               s[right--] = temp;
            }
        }
    }
}

using System;

namespace ConsoleApplication
{
    //确定一个字符串的所有字符是否完全不同 --> 假设只有26个字母
    public class ISUniqueCharClass {
        public void print() {
            ISUniqueChar("aaaab");
        }
        //用bool[]保存状态
        public bool ISUniqueChar(string str){
            if(str.Length > 256) return false;
            bool[] res = new bool[26];
            foreach (char c  in str)
            {
                int offset = c-'a';
                if(res[offset]) return false;
                res[offset] = true;
            }
            return true;
        }

        //用位保存状态
        public bool ISUniqueChar2(string str){
            if(str.Length > 26) return false;
            int res = 0;
            foreach(char c in str){
                int val = c-'a';
                if((res & (1 << val)) != 0) return false;
                res |= (1 << val);
            }
            return true;
        }
    }
    
}
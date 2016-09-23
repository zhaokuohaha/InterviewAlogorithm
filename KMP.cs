using System;

namespace ConsoleApplication{
    public class KMPClass{
        public void print(){
            string str = "BBC ABCDAB ABCDABCDABDE";
            string mode = "ABCDABD";
            Console.WriteLine("Voilent: "+Voilent(str,mode));
            Console.WriteLine("KMP: "+Kmp(str,mode));
        }

        //暴力
        public int Voilent(string str, string mode){
            int i=0,j=0;
            while(i<str.Length && j < mode.Length){
                if(str[i]==mode[j]){
                    i++;
                    j++;
                }else{
                    i=i-j+1;
                    j=0;
                }
            }

            if(j==mode.Length)
                return i-j;
            return -1;
        }

        
        //KMP 
        public int Kmp(string str, string mode){
            int[] next = GetNext(mode);
            int i=0, j=0;
            while(i<str.Length && j<mode.Length){
                if(str[i] == mode[j] || next[j]==-1){
                    i++;
                    j++;
                }else{
                    j=next[j];
                }
            }
            if(j==mode.Length)
                return i-j;
            return -1;
        }

        //求next数组
        private int[] GetNext(string mode){
            int[] next = new int[mode.Length];
            next[0] = -1;
            int k=-1, j=0;
            while(j<mode.Length-1){
                if(k==-1 || mode[j] == mode[k]){
                    ++j;++k;
                    if(mode[j] != mode[k])
                        next[j] = k;
                    else 
                        next[j] = next[k];
                }else{
                    k = next[k];
                }
            }
            return next;
        }
    }
}
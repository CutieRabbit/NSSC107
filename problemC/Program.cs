using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problemC {
    class Program {
        static void Main(string[] args) {
            Console.Write("請輸入密碼：");
            String password = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("密碼長度：" + password.Length);
            int uppperCase = 0, lowerCase = 0, number = 0, sign = 0;
            bool[] contain = new bool[4];
            for (int i = 0; i < password.Length; i++) {
                char c = password[i];
                if(c >= 'A' && c <= 'Z') {
                    uppperCase++;
                    contain[0] = true;
                    continue;
                }
                if(c >= 'a' && c <= 'z') {
                    lowerCase++;
                    contain[1] = true;
                    continue;
                }
                if(c >= '0' && c <= '9') {
                    number++;
                    contain[2] = true;
                    continue;
                }
                sign++;
                contain[3] = true;
            }
            Console.WriteLine("大寫英文字母長度：" + uppperCase);
            Console.WriteLine("小寫英文字母長度：" + lowerCase);
            Console.WriteLine("數字長度：" + number);
            Console.WriteLine("符號長度：" + sign);
            int containCount = 0;
            for(int i = 0; i < contain.Length; i++) {
                if(contain[i] == true) {
                    containCount += 1;
                }
            }
            if(containCount >= 3) {
                Console.WriteLine("符合密碼規則");
            }
            else {
                Console.WriteLine("不符密碼規則");
            }
        }
    }
}//finish at 31min
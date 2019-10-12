using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problemE {
    class Program {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] data = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            for(int i = 0; i < data.Length; i++) {
                array[i] = Convert.ToInt32(data[i]);
            }
            int answer = -999, fa = 0, fb = 0;
            for(int i = 0; i < n; i++) {
                int count = 0;
                for(int j = i; j < n; j++) {
                    count = count + array[j];
                    if (count > answer) {
                        fa = i;
                        fb = j;
                        answer = count;
                    }
                } 
            }
            Console.WriteLine(answer);
            Console.WriteLine(fa + " " + fb);
        }
    }
}//finish at 41min

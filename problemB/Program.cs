using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace problemB {
    class Program {
        static void print(List<double> array) {
            for(int i = 0; i < array.Count; i++) {
                Console.Write(String.Format("{0:0.00 }",array[i]));
            }
            Console.WriteLine();
        }
        static void Main(string[] args) {
            Console.Write("請輸入資料檔名：");
            String path = Console.ReadLine();
            StreamReader reader = new StreamReader(path);
            List<double> data1 = new List<double>();
            List<double> data2 = new List<double>();
            List<double> data3 = new List<double>();
            List<double> PDM = new List<double>();
            List<double> MDM = new List<double>();
            List<double> DX = new List<double>();
            List<double> TR = new List<double>();
            List<double> ADX = new List<double>();
            for(int i = 0; i <= 35; i++) {
                data1.Add(0);
                data2.Add(0);
                data3.Add(0);
                PDM.Add(0);
                MDM.Add(0);
                DX.Add(0);
                TR.Add(0);
                ADX.Add(0);
            }
            for (int i = 0; i < 6; i++) {
                String line = reader.ReadLine();
                if (i % 2 == 0) continue;
                String[] split = line.Split(' ');
                for (int j = 1; j <= split.Length; j++) {
                    if (i == 1) {
                        data1[j] = (Convert.ToDouble(split[j-1]));
                    }else if(i == 3) {
                        data2[j] = (Convert.ToDouble(split[j-1]));
                    }else if(i == 5) {
                        data3[j] = (Convert.ToDouble(split[j-1]));
                    }
                }
            }
            
            for(int i = 2; i <= 35; i++) {
                PDM[i] = data1[i] - data1[i-1];
                if (PDM[i] < 0) PDM[i] = 0;
            }
            for (int i = 2; i <= 35; i++) {
                MDM[i] = data3[i-1] - data3[i];
                if (MDM[i] < 0) MDM[i] = 0;
            }
            
            for (int i = 2; i <= 35; i++) {
                if(PDM[i] < MDM[i]) {
                    PDM[i] = 0;
                }else if(PDM[i] == MDM[i]) {
                    PDM[i] = 0;
                    MDM[i] = 0;
                }else if(PDM[i] > MDM[i]) {
                    MDM[i] = 0;
                }
            }
            print(PDM);
            print(MDM);
            for (int i = 2; i <= 35; i++) {
                double a = Math.Abs(data1[i] - data3[i]);
                double b = Math.Abs(data1[i] - data2[i-1]);
                double c = Math.Abs(data3[i] - data2[i-1]);
                TR[i] = Math.Max(a, Math.Max(b, c));
            }
            for(int i = 11; i <= 35; i++) {
                double TRtotal = 0;
                double PDMtotal = 0;
                double MDMtotal = 0;
                for (int j = i; j >= i-9; j--) {
                    TRtotal += TR[j];
                    PDMtotal += PDM[j];
                    MDMtotal += MDM[j];
                }
                double PDI = (PDMtotal/10.0) / (TRtotal/10.0);
                double MDI = (MDMtotal/10.0) / (TRtotal/10.0);
                DX[i] = 100.0 * (Math.Abs(PDI - MDI) / (PDI + MDI));
            }
            for (int i = 20; i <= 35; i++) {
                double total = 0;
                for (int j = i; j >= i - 9; j--) {
                    total += DX[j];
                }
                ADX[i] = total / 10.0;
            }
            Console.Write("ADX： ");
            for (int i = 21; i <= 35; i++) {
                Console.Write(String.Format("{0:0.00}",ADX[i]).PadRight(7,' '));
            }
            Console.WriteLine();
            Console.Write("預測： ");
            for (int i = 21; i <= 35; i++) {
                double val = ADX[i - 1] <= ADX[i] ? 1 : 0;
                Console.Write(val.ToString().PadRight(6, ' '));
            }
            Console.WriteLine();
        }
    }
}//finish at 128min

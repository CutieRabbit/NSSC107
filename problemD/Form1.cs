using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace problemD {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        List<List<double>> array = new List<List<double>>();
        int N = 0;

        private void 選取資料ToolStripMenuItem_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt";
            ofd.ShowDialog();
            String path = ofd.FileName;
            StreamReader sr = new StreamReader(path);
            List<String> list = new List<string>();
            String line;
            while ((line = sr.ReadLine()) != null) {
                list.Add(line);
            }
            for(int i = 0; i < list.Count; i++) {
                String[] split = list[i].Split(' ');
                array.Add(new List<double>());
                for (int j = 0; j < split.Length; j++) {
                    array[i].Add(Convert.ToDouble(split[j]));
                    N++;
                }
            }
            for(int i = 0; i < list.Count; i++) {
                String str = "麵[" + (i+1) + "]:";
                for(int j = 0; j < array[i].Count; j++) {
                    str += String.Format("{0:0.00}",array[i][j]).PadLeft(6, ' ');
                }
                textBox1.Text += str + Environment.NewLine;
            }
            
        }

        private void 求F統計值與自由度dfToolStripMenuItem_Click(object sender, EventArgs e) {
            double F = getF();
            textBox2.Text = "F統計值計算：" + F.ToString() + Environment.NewLine;
            textBox2.Text += String.Format("自由度df：{0},{1}", array.Count - 1, N - array.Count);
        }

        public double getuti(int i) {
            double total = 0;
            for (int j = 0; j < array[i].Count; j++) {
                total += array[i][j];
            }
            total /= (1.0 * array[i].Count);
            return total;
        }

        public double getUT() {
            double total = 0;
            for(int i = 0; i < array.Count; i++) {
                for(int j = 0; j < array[i].Count; j++) {
                    total += array[i][j];
                }
            }
            return total / N;
        }

        public double getSSb() {
            double total = 0;
            for (int i = 0; i < array.Count; i++) {
                double a = Convert.ToDouble(array[i].Count);
                double ut = getuti(i);
                double UT = getUT();
                total += a * Math.Pow((ut - UT), 2);
            }
            return total;
        }
        public double getSSw() {
            double total = 0;
            for(int i = 0; i < array.Count; i++) {
                double ut = getuti(i);
                for (int j = 0; j < array[i].Count; j++) {
                    total += Math.Pow((array[i][j] - ut), 2);
                }
            }
            return total;
        }

        public double getMsb() {
            return getSSb() / ((array.Count - 1) * 1.0);
        }
        
        public double getMsw() {
            return getSSw() / ((N - array.Count) * 1.0);
        }

        public double getF() {
            return getMsb() / getMsw();
        }
    }
}//88min
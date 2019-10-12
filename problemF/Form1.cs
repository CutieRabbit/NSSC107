using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemF {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e) {
            Random random = new Random();
            int n = random.Next(26, 51);
            string str = "";
            for(int i = 0; i < n; i++) {
                str += random.Next(0, 2);
            }
            textBox1.Text = str;
        }

        private void Button4_Click(object sender, EventArgs e) {
            Random random = new Random();
            int n = random.Next(26, 51);
            string str = "";
            for (int i = 0; i < n; i++) {
                str += random.Next(0, 2);
            }
            textBox4.Text = str;
        }

        public void decoding(TextBox input, TextBox output, TextBox status) {
            string data = input.Text;
            int n = data.Length;
            string[] array = { "10", "01", "11", "001", "000" };
            string[] sign = { "A", "B", "C", "D", "E" };
            string result = "";
            for(int i = 0; i < n;) {
                string str = data.Substring(i, Math.Min(2, data.Length-i));
                if(str == "00") {
                    bool find = false;
                    str = data.Substring(i, Math.Min(3, data.Length-i));
                    for(int j = 0; j < array.Length; j++) {
                        if(str == array[j]) {
                            result += sign[j];
                            find = true;
                        }
                    }
                    if(find == false) {
                        output.Text = "";
                        status.Text = "不合理";
                        break;
                    }
                    i += 3;
                }
                else {
                    bool find = false;
                    for(int j = 0; j < array.Length; j++) {
                        if(str == array[j]) {
                            result += sign[j];
                            find = true;
                        }
                    }
                    if(find == false) {
                        output.Text = "";
                        status.Text = "不合理";
                        break;
                    }
                    i += 2;
                }
                output.Text = result;
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            decoding(textBox1, textBox3, textBox2);
            decoding(textBox4, textBox6, textBox5);
        }

        private void Button2_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
    }
}//finish at 57min
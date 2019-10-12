using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemA {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string[] str = { "100001", "100010", "100100", "001100", "010100", "100100" };
        Point[] point = { new Point(30, 100), new Point(30, 150), new Point(30, 200), new Point(150, 300), new Point(200, 300), new Point(250, 300) };
        Brush[] color = { Brushes.Red, Brushes.Yellow , Brushes.Green, Brushes.Red, Brushes.Yellow, Brushes.Green };
        string[] word = { "R1", "A1", "G1", "R2", "A2", "G2" };

        private void Form1_Load(object sender, EventArgs e) {
            Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);        
            pictureBox1.Image = bmp;
        }

        int index = 0;

        private void Button1_Click(object sender, EventArgs e) {
            index = 0;
            draw();
        }

        public void init() {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            for (int i = 0; i < 6; i++) {
                graphics.DrawString(word[i], new Font("Consolas", 16), Brushes.Black, point[i]);
            }
            graphics.DrawLine(new Pen(Color.Black), 100, 0, 100, 378);
            graphics.DrawLine(new Pen(Color.Black), 130, 0, 130, 378);
            graphics.DrawLine(new Pen(Color.Black), 0, 250, 406, 250);
            graphics.DrawLine(new Pen(Color.Black), 0, 280, 406, 280);
            pictureBox1.Image = bmp;
        }

        public void draw() {
            init();
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Graphics graphics = Graphics.FromImage(bmp);
            for (int i = 0; i < str[index].Length; i++) {
                if (str[index][i] == '1') {
                    graphics.FillEllipse(color[i], point[i].X - 10, point[i].Y - 10, 50, 50);
                    graphics.DrawString(word[i], new Font("Consolas", 16), Brushes.Black, point[i]);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void Button2_Click(object sender, EventArgs e) {
            index++;
            index %= 6;
            draw();
        }

        private void Button3_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
    }
}//finish at 24min

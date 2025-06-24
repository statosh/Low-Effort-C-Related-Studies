using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _20_06 {
    public partial class Form2 : Form {
        string text;
        int X, Y;
        Form1 fmain;
        public Form2(Form1 main) {
            InitializeComponent();
            fmain = main;
        }

        private void button1_Click(object sender, EventArgs e) {
            text = textBox1.Text;
            if (text == "") {
                MessageBox.Show("Введите текс", "Внимание", MessageBoxButtons.OK);
                return;
            }
            X = (int)numericUpDownX.Value;
            Y = (int)numericUpDownY.Value;
            fmain.text = text;
            fmain.X = X;
            fmain.Y = Y;
            Graphics g = this.CreateGraphics();
            fmain.DrawText(g, text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            fmain.X = -1;
            fmain.Y = -1;
            fmain.text = null;
            this.Close();
        }


    }

}

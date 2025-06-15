using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4 {
    public partial class Form1 : Form {
        private float d1, d2, res;
        private int op;
        public Form1() {
            InitializeComponent();
            label1.Text = label2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e) {
            op = 0;
        }

        //обработчик кнопки- знака
        private void button1_Click(object sender, EventArgs e) {
            if (is_number()) {
                copy_number(1);
            } else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (is_number()) {
                copy_number(2);
            } else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (is_number()) {
                copy_number(3);
            } else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (is_number()) {
                copy_number(4);
            } else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private void button7_Click(object sender, EventArgs e) {
            if (is_number()) {
                copy_number(5);
            } else { textBox1.SelectAll(); textBox1.Focus(); }
        }

        private void button5_Click(object sender, EventArgs e) {
            if (op != 0 && is_number()) {
                switch (op) {
                    case 1:
                        try {
                            res = d1 * d2;
                        } catch (Exception) {
                            MessageBox.Show("Переполненние");
                            return;
                        }
                        break;
                    case 2:
                        try {
                            res = d1 / d2;
                        } catch (Exception) {
                            MessageBox.Show("Деление на ноль");
                            return;
                        }
                        break;
                    case 3:
                        res = d1 + d2;
                        break;
                    case 4:
                        res = d1 - d2;
                        break;
                    case 5:
                        res = (float) Math.Pow(d1, d2);
                        break;
                }
                label1.Text += label2.Text + textBox1.Text + "=" + res;
                label2.Text = "";
                textBox1.Text = res.ToString();
                op = 0;
                textBox1.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            textBox1.Clear();
            label1.Text = label2.Text = "";
            op = 0;
            textBox1.Focus();
        }


        //обработчики на кнопку 2,3,4 необходимо дополнить

        private bool is_number() {
            float d;
            bool Is_Num = Single.TryParse(textBox1.Text, System.Globalization.NumberStyles.Number,
                System.Globalization.NumberFormatInfo.CurrentInfo, out d);
            textBox1.Focus();
            if (Is_Num) {
                if (op == 0) d1 = d; else d2 = d;
                return true;
            }
            return false;
        }


        private void copy_number(int op) {
            this.op = op;
            label1.Text = textBox1.Text;
            if (op == 1) label2.Text = "*";
            else if (op == 2) label2.Text = "/";
            else if (op == 3) label2.Text = "+";
            else if (op == 4) label2.Text = "-";
            else if (op == 5) label2.Text = "^";
            textBox1.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_06 {
    public partial class Form1 : Form {
        private int deliveryNum = 1;
        public Form1() {
            InitializeComponent();
        }
        private void inval() {
            string text = "- Заказ: " + deliveryNum + "\r\n";
            text += "\r\n- Доп. услуги: \r\n";
            text += checkBox1.CheckState == CheckState.Checked ? "    " + checkBox1.Text + "\r\n" : "";
            text += checkBox2.CheckState == CheckState.Checked ? "    " + checkBox2.Text + "\r\n" : "";
            text += checkBox3.CheckState == CheckState.Checked ? "    " + checkBox3.Text + "\r\n" : "";
            text += "\r\n- Доставка: \r\n";
            text += radioButton1.Checked ? "    " + radioButton1.Text + "\r\n" : "    " + radioButton2.Text + "\r\n";

            textBox1.Text = text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            inval();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            inval();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            inval();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            inval();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            inval();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("Заказ " + deliveryNum + " сформирован");
            deliveryNum += 1;
            inval();
        }
    }
}

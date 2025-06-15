using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._06 {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (radioButton1.Checked) {
                textBox1.Text = Convert.ToString(Math.Sin((double)numericUpDown1.Value));
            } else if (radioButton2.Checked) {
                textBox1.Text = Convert.ToString(Math.Cos((double)numericUpDown1.Value));
            }
        }
    }
}

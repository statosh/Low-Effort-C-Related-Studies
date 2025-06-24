using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_06_02 {
    public partial class Form1 : Form {
        private int currentPlayer = 0;
        public Form1() {
            InitializeComponent();
        }
        private void re_paint() {
            panel0_0.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel0_1.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel0_2.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel1_0.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel1_1.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel1_2.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel2_0.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel2_1.BackColor = Color.FromArgb(255, 255, 192, 128);
            panel2_2.BackColor = Color.FromArgb(255, 255, 192, 128);
        }
        private void button1_Click(object sender, EventArgs e) {
            re_paint();
        }
        private void button2_Click(object sender, EventArgs e) {
            re_paint();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void cell_mouseover(object sender, EventArgs e) {
            if (sender is Panel) {
                Panel cellpanel = (Panel)sender;
                cellpanel.BackColor = Color.FromArgb(200, 255, 192, 128);
                Cursor = Cursors.Hand;
            }
        }
        private void cell_mouseout(object sender, EventArgs e) {
            if (sender is Panel) {
                Panel cellpanel = (Panel)sender;
                cellpanel.BackColor = Color.FromArgb(255, 255, 192, 128);
                Cursor = Cursors.Default;
            }
        }
        private void cell_change(object sender, EventArgs e) {
            if (sender is Panel) {
                Panel cellpanel = (Panel)sender;
                if (currentPlayer == 0) {
                    cellpanel.BackgroundImage = Image.FromFile(@"Z:\Desktop\krestik.png");
                } else if (currentPlayer == 1) {
                    cellpanel.BackgroundImage = Image.FromFile(@"Z:\Desktop\nolik.png");
                }
            }
        }
    }
}

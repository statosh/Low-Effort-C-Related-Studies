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
        private GameEngine gameEngine = new GameEngine();
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

        private void FillCell(Panel panel, int row, int column) {
            if (panel.Controls.Count == 0) {
                Label label = new Label {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Franklin Gothic Medium", 24F, FontStyle.Bold),
                    Text = gameEngine.IsPlayer1HumanTurn() ? "X" : "O",
                    ForeColor = gameEngine.GetCurrentMarkLabelColor()
                };
                panel.Controls.Add(label);

                gameEngine.MakeTurnAndFillGameFieldCell(row, column);
            }
        }

        private void panelCell0_0_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 0, 0);
        }

        private void panelCell0_1_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 0, 1);
        }

        private void panelCell0_2_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 0, 2);
        }

        private void panelCell1_0_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 1, 0);
        }

        private void panelCell1_1_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 1, 1);
        }

        private void panelCell1_2_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 1, 2);
        }

        private void panelCell2_0_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 2, 0);
        }

        private void panelCell2_1_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 2, 1);
        }

        private void panelCell2_2_Click(object sender, EventArgs e) {
            FillCell((Panel)sender, 2, 2);
        }

    }
}

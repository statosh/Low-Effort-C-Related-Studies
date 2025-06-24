using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_06 {
    public partial class Form3 : Form {
        Form1 Fm;
        int X, Y, W, H;

        private void button2_Click(object sender, EventArgs e) {
            Fm.H = -1;
            Fm.W = -1;
            Fm.Y = -1;
            Fm.X = -1;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            X = (int)numericUpDownX.Value;
            Y = (int)numericUpDownY.Value;
            W = (int)numericUpDown2.Value;  // Width
            H = (int)numericUpDown1.Value;  // Height

            Fm.X = X;
            Fm.Y = Y;
            Fm.W = W;
            Fm.H = H;

            // Get the active menu item from Form1 to determine which shape to draw
            if (Fm.ActiveMenuItem != null) {
                Graphics g = Fm.CreateGraphics();

                switch (Fm.ActiveMenuItem) {
                    case "контурToolStripMenuItem":  // Rectangle outline
                        Fm.DrawRectangl(g, X, Y, W, H);
                        break;
                    case "заливкаToolStripMenuItem":  // Rectangle fill
                        Fm.DrawRectanglFill(g, X, Y, W, H);
                        break;
                    case "контурToolStripMenuItem1":  // Ellipse outline
                        Fm.DrawEllipse(g, X, Y, W, H);
                        break;
                    case "заливкаToolStripMenuItem1":  // Ellipse fill
                        Fm.DrawEllipseFull(g, X, Y, W, H);
                        break;
                    case "контурToolStripMenuItem2":  // Polygon outline
                        Fm.DrawPolygon(g);
                        break;
                    case "заливкаToolStripMenuItem2":  // Polygon fill
                        Fm.DrawPolygonFill(g);
                        break;
                    case "контурToolStripMenuItem3":  // Pie outline
                        Fm.DrawPies(g, X, Y, W, H);
                        break;
                    case "заливкаToolStripMenuItem3":  // Pie fill
                        Fm.DrawPiesFill(g, X, Y, W, H);
                        break;
                    case "дугаToolStripMenuItem":  // Arc
                        Fm.DrawArc(g, X, Y, W, H);
                        break;
                    case "сплошнаяToolStripMenuItem":  // Solid line
                        Fm.DrawSolidLine(g, X, Y, W, H);
                        break;
                    case "прерывистаяToolStripMenuItem":  // Dash line
                        Fm.DrawDashLine(g, X, Y, W, H);
                        break;
                    case "пунктирнаяToolStripMenuItem":  // DashDot line
                        Fm.DrawDashDotLine(g, X, Y, W, H);
                        break;
                }
                g.Dispose();
            }
            this.Close();
        }

        public Form3(Form1 fm) {
            InitializeComponent();
            Fm = fm;
        }
    }
}
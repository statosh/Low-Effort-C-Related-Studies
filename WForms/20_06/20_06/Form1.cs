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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public string text { get; set; }
        public string ActiveMenuItem { get; set; }

        private void написатьToolStripMenuItem_Click(object sender, EventArgs e) {
            Form2 dt = new Form2(this);
            dt.ShowDialog();
            Graphics G = CreateGraphics();
            DrawText(G, text);
            G.Dispose();
        }

        private void GetForm3() {
            Form3 dp = new Form3(this);
            dp.ShowDialog();
        }

        private void ResetData() {
            X = -1;
            Y = -1;
            W = -1;
            H = -1;
        }

        private void контурToolStripMenuItem_Click(object sender, EventArgs e) {
            ActiveMenuItem = "контурToolStripMenuItem";
            GetForm3();
        }

        private void заливкаToolStripMenuItem_Click(object sender, EventArgs e) {
            ActiveMenuItem = "заливкаToolStripMenuItem";
            GetForm3();
        }

        private void контурToolStripMenuItem1_Click(object sender, EventArgs e) {
            ActiveMenuItem = "контурToolStripMenuItem1";
            GetForm3();
        }

        private void заливкаToolStripMenuItem1_Click(object sender, EventArgs e) {
            ActiveMenuItem = "заливкаToolStripMenuItem1";
            GetForm3();
        }

        private void контурToolStripMenuItem2_Click(object sender, EventArgs e) {
            ActiveMenuItem = "контурToolStripMenuItem2";
            GetForm3();
        }

        private void заливкаToolStripMenuItem2_Click(object sender, EventArgs e) {
            ActiveMenuItem = "заливкаToolStripMenuItem2";
            GetForm3();
        }

        private void контурToolStripMenuItem3_Click(object sender, EventArgs e) {
            ActiveMenuItem = "контурToolStripMenuItem3";
            GetForm3();
        }

        private void заливкаToolStripMenuItem3_Click(object sender, EventArgs e) {
            ActiveMenuItem = "заливкаToolStripMenuItem3";
            GetForm3();
        }

        private void дугаToolStripMenuItem_Click(object sender, EventArgs e) {
            ActiveMenuItem = "дугаToolStripMenuItem";
            GetForm3();
        }

        private void сплошнаяToolStripMenuItem_Click(object sender, EventArgs e) {
            ActiveMenuItem = "сплошнаяToolStripMenuItem";
            GetForm3();
        }

        private void прерывистаяToolStripMenuItem_Click(object sender, EventArgs e) {
            ActiveMenuItem = "прерывистаяToolStripMenuItem";
            GetForm3();
        }

        private void пунктирнаяToolStripMenuItem_Click(object sender, EventArgs e) {
            ActiveMenuItem = "пунктирнаяToolStripMenuItem";
            GetForm3();
        }

        public void DrawText(Graphics g, string r) {
            string str = r;
            Font font = new Font("Arial", 26);
            SizeF sizeString = g.MeasureString(str, font);
            g.DrawString(str, font, Brushes.Orchid, new PointF(200, 100));
            font.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        public void DrawEllipse(Graphics g, int x, int y, int h, int w) {
            Rectangle ell = new Rectangle(x, y, h, w);
            g.DrawEllipse(Pens.Red, ell);
        }

        public void DrawEllipseFull(Graphics g, int x, int y, int h, int w) {
            Rectangle ell = new Rectangle(x, y, h, w);
            g.FillEllipse(Brushes.Purple, ell);
        }

        public void DrawRectangl(Graphics g, int x, int y, int h, int w) {
            Pen greenPen = new Pen(Brushes.Green, 2f);
            greenPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawRectangle(greenPen, new Rectangle(x, y, h, w));
            greenPen.Dispose();
        }

        public void DrawRectanglFill(Graphics g, int x, int y, int h, int w) {
            g.FillRectangle(Brushes.Cyan, new Rectangle(x, y, h, w));
        }

        public void DrawPolygon(Graphics g) {
            Pen bluePen = new Pen(Brushes.DarkCyan, 1.5f);
            bluePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.DrawPolygon(bluePen, new Point[]
            {
                new Point(230,10),
                new Point(370,30),
                new Point(310,50),
                new Point(240,50),
            });
            bluePen.Dispose();
        }

        public void DrawPolygonFill(Graphics g) {
            g.FillPolygon(Brushes.Chocolate,
                new Point[] {
                new Point(230,130),
                new Point(370,130),
                new Point(310,150),
                new Point(240,150),
                });
        }

        public void DrawArc(Graphics g, int x, int y, int h, int w) {
            g.DrawArc(Pens.Indigo, new Rectangle(x, y, h, w), 270, 180);
        }

        public void DrawPies(Graphics g, int x, int y, int h, int w) {
            g.DrawPie(Pens.DarkRed, new Rectangle(x, y, h, w), 90, 70);
        }

        public void DrawPiesFill(Graphics g, int x, int y, int h, int w) {
            g.FillPie(Brushes.DarkOrange, new Rectangle(x, y, h, w), 90, 70);
        }

        public void DrawSolidLine(Graphics g, int x1, int y1, int x2, int y2) {
            g.DrawLine(Pens.Gray, new Point(x1, y1), new Point(x2, y2));
        }

        public void DrawDashLine(Graphics g, int x1, int y1, int x2, int y2) {
            Pen npen = new Pen(Color.Black, 5);
            npen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(npen, new Point(x1, y1), new Point(x2, y2));
            npen.Dispose();
        }

        public void DrawDashDotLine(Graphics g, int x1, int y1, int x2, int y2) {
            Pen npen = new Pen(Color.Black, 1);
            npen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            g.DrawLine(npen, new Point(x1, y1), new Point(x2, y2));
            npen.Dispose();
        }
    }
}
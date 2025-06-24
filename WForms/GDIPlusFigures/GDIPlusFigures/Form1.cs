using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDIPlusFigures {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = Pens.Black;
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush brownBrush = new SolidBrush(Color.Brown);
            SolidBrush blueBrush = new SolidBrush(Color.LightBlue);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

            g.FillRectangle(brownBrush, 20, 80, 20, 40);            
            g.FillEllipse(greenBrush, 10, 40, 40, 50);             

            Point[] triangleTop = { new Point(100, 20), new Point(90, 40), new Point(110, 40) };
            Point[] triangleMiddle = { new Point(100, 35), new Point(80, 60), new Point(120, 60) };
            Point[] triangleBottom = { new Point(100, 55), new Point(70, 90), new Point(130, 90) };
            g.FillPolygon(greenBrush, triangleBottom);
            g.FillPolygon(greenBrush, triangleMiddle);
            g.FillPolygon(greenBrush, triangleTop);
            g.FillRectangle(brownBrush, 90, 90, 20, 30);

            g.FillRectangle(blueBrush, 160, 60, 60, 60);           
            g.FillRectangle(brownBrush, 203, 38, 10, 15);            
            Point[] roof = { new Point(160, 60), new Point(190, 30), new Point(220, 60) };
            g.FillPolygon(redBrush, roof);                         

            g.FillRectangle(yellowBrush, 250, 80, 60, 30);         
            g.FillRectangle(yellowBrush, 250, 60, 20, 20);         
            g.FillEllipse(redBrush, 255, 110, 15, 15);             
            g.FillEllipse(redBrush, 290, 110, 15, 15);
        }
    }
}

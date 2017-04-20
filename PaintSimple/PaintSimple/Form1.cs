using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintSimple
{
    public partial class Form1 : Form
    {
        enum Shape
        {
            LINE,
            RECTANGLE,
            ELLIPSE,
            FREE,
            FILL
        };
        Queue<Point> q = new Queue<Point>();
        Shape shape = Shape.LINE;
        MyPaint paint = new MyPaint();
        Graphics g;
        bool mouseClicked = false;
        Point prevPoint = new Point(0, 0);
        Graphics gPic;
        Bitmap bmp;
        Color Cur;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            gPic = pictureBox1.CreateGraphics();
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
        }
        void step (int x, int y)
        {
            if (x >= bmp.Width)
                return;
            if (x <= 0)
                return;
            if (y >= bmp.Height)
                return;
            if (y <= 0)
                return;
            if (bmp.GetPixel(x, y) != Cur)
                return;
            if (Cur == paint.pen.Color)
                return;
            q.Enqueue(new Point(x, y));
            bmp.SetPixel(x, y, paint.pen.Color);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
            MessageBox.Show(paint.pen.Color.ToString());
            int w = Math.Abs(prevPoint.X - e.Location.X);
            int h = Math.Abs(prevPoint.Y - e.Location.Y);
            int minX = Math.Min(prevPoint.X, e.Location.X);
            int minY = Math.Min(prevPoint.Y, e.Location.Y);
            if (shape == Shape.RECTANGLE)
                g.DrawRectangle(paint.pen, minX, minY, w, h);
            else if (shape == Shape.ELLIPSE)
                g.DrawEllipse(paint.pen, minX, minY, w, h);
            else if (shape == Shape.FILL)
            {
                q.Enqueue(e.Location);
                Cur = bmp.GetPixel(e.Location.X, e.Location.Y);
                while (q.Count() >= 1)
                {
                    int x = q.First().X;
                    int y = q.First().Y;
                    q.Dequeue();
                    step(x + 1, y);
                    step(x, y + 1);
                    step(x - 1, y);
                    step(x, y - 1);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                if (shape == Shape.LINE)
                {
                    g.DrawLine(paint.pen, prevPoint.X, prevPoint.Y, e.Location.X, e.Location.Y);
                    prevPoint = e.Location;
                }
                else if (shape == Shape.RECTANGLE)
                {
                    int w = Math.Abs(prevPoint.X - e.Location.X);
                    int h = Math.Abs(prevPoint.Y - e.Location.Y);
                    int minX = Math.Min(prevPoint.X, e.Location.X);
                    int minY = Math.Min(prevPoint.Y, e.Location.Y);

                    gPic.DrawRectangle(paint.pen, minX, minY, w, h);
                }
                else if (shape == Shape.ELLIPSE)
                {
                    int w = Math.Abs(prevPoint.X - e.Location.X);
                    int h = Math.Abs(prevPoint.Y - e.Location.Y);
                    int minX = Math.Min(prevPoint.X, e.Location.X);
                    int minY = Math.Min(prevPoint.Y, e.Location.Y);
                    gPic.DrawEllipse(paint.pen, minX, minY, w, h);
                }
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paint.penColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint.penColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint.penColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paint.penColor = Color.Yellow;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            paint.pen.Width = trackBar1.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shape = Shape.LINE;
            paint.pen.Color = paint.penColor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shape = Shape.RECTANGLE;
            paint.pen.Color = paint.penColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                paint.pen.Color = c.Color;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shape = Shape.ELLIPSE;
            paint.pen.Color = paint.penColor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            shape = Shape.LINE;
            paint.pen.Color = Color.White;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            shape = Shape.FILL;
            paint.pen.Color = paint.penColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroid
{
    public partial class Form1 : Form
    {
        public Point[] a = new Point[1000];
        int n = 0;
        public bool InStar(int x, int y)
        {
            if (y - 100 <= 320 && y + 100 >= 320 && x - 100 <= 501 && x + 100 >= 501)
                return true;

            for (int i = 1; i <= n; ++i)
            {
                if (a[i].X + 25 >= x && a[i].X - 25 <= x && a[i].Y + 25 >= y && a[i].Y - 25 <= y)
                    return true;
            }

            return false;
        }
        public bool InStar2(int x, int y)
        {
            if (y - 100 <= 320 && y + 100 >= 320 && x - 100 <= 501 && x + 100 >= 501)
                return true;

            for (int i = 1; i <= n; ++i)
            {
                if (a[i].X + 55 >= x && a[i].X - 55 <= x && a[i].Y + 55 >= y && a[i].Y - 55 <= y)
                    return true;
            }
            return false;
        }
        Graphics g;
        void Add_Asteroids()
        {
            if (n < 20)
            {
                for (int i = 11; i <= 20; ++i)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    int x = rnd.Next(900);
                    int y = rnd.Next(600);
                    while (InStar2(x, y))
                    {
                        x = rnd.Next(800);
                        y = rnd.Next(500);
                    }
                    ++n;
                    a[n] = new Point(x, y);
                }
            }
            for (int i = 11; i <= n; ++i)
            {
                int x = a[i].X;
                int y = a[i].Y;
                Point[] DOWN = new Point[] { new Point(x + 0, y + 50), new Point(x + 30, y + 0), new Point(x + 60, y + 50) };
                Point[] UP = new Point[] { new Point(x + 0, y + 17), new Point(x + 60, y + 17), new Point(x + 30, y + 67) };
                g.FillPolygon(new SolidBrush(Color.Green), UP);
                g.FillPolygon(new SolidBrush(Color.Green), DOWN);
            }
        }
        void Add_Stars ()
        {
            if (n < 10)
            {
                for (int i = 1; i <= 10; ++i)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    int x = rnd.Next(900);
                    int y = rnd.Next(600);
                    while (InStar(x, y))
                    {
                        x = rnd.Next(800);
                        y = rnd.Next(500);
                    }
                    ++n;
                    a[n] = new Point(x, y);
                }
            }
            for (int i = 1; i <= 10; ++i)
            {
                int x = a[i].X;
                int y = a[i].Y;
                g.FillEllipse(new SolidBrush(Color.White), x, y, 30, 30);
                g.FillEllipse(new SolidBrush(Color.White), x, y, 30, 30);
            }
        }
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(@"C:\Users\Elibay\Desktop\397989.jpg");
            g = pictureBox1.CreateGraphics();
            pictureBox1.Image = bmp;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Refresh();
            Add_Stars();
            Add_Asteroids();
            int x = pictureBox1.Height / 2;
            int y = pictureBox1.Width / 2;
            //MessageBox.Show(x.ToString());
            Image img = Image.FromFile(@"C:\Users\Elibay\Desktop\tank12.png");
            y -= img.Size.Width / 2;
            x -= img.Size.Height / 2;
            g.DrawImage(img, y, x);
               
        }
        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double x1 = e.Location.X, y1 = e.Location.Y;
            int x = pictureBox1.Height / 2;
            int y = pictureBox1.Width / 2;
            Image img = Image.FromFile(@"C:\Users\Elibay\Desktop\tank12.png");
            y -= img.Size.Width / 2;
            x -= img.Size.Height / 2;
            double x2 = x, y2 = y;
            double q = Math.Atan2(y1 - y2, x1 - x2) / Math.PI * 180;
            string s = q.ToString();
            float A = float.Parse (s);
            A = (A < 0) ? A + 360 : A;
            bmp = RotateImage(img, new Point (x, y), A);
            

        }
    }
}

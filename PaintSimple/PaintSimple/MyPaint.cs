using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaintSimple
{
    public class MyPaint
    {
        public Color penColor;
        public Color brushColor;
        public Pen pen;
        public Brush brush;
        public MyPaint ()
        {
            penColor = Color.Black;
            brushColor = Color.Black;
            pen = new Pen(penColor);
            brush = new SolidBrush(brushColor);
        }
    }
}

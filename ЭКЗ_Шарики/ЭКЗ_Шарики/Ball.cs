using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЭКЗ_Шарики
{
    public class Ball
    {
        public int x0;
        public int y0;
        public int Radius = 6;
        public Brush color = new SolidBrush(Color.White);
        public Ball(int X, int Y, Brush color)
        {
            this.x0 = X;
            this.y0 = Y;
            this.color = color;
        }
    }
}

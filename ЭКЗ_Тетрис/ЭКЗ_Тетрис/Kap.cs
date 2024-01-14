using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЭКЗ_Тетрис
{
    public class Kap
    {
        public int speed = 1;

        public int x0 = 0;
        public int y0 = 0;
        public Color color = Color.White;
        public Kap(int x, int y, int speed, Color color)
        {
            this.x0 = x;
            this.y0 = y;
            this.speed = speed;
            this.color = color;
        }
    }
}

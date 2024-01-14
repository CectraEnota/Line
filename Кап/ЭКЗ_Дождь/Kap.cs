using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЭКЗ_Дождь
{
    public class Kap
    {
        public int speed = 0;

        public int x0 = 0;
        public int y0 = 0;
        public Kap(int x, int y, int speed)
        {
            this.x0 = x;
            this.y0 = y;
            this.speed = speed;

        }
    }
}

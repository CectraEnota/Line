using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЭКЗ_Дождь
{
    public class Tycha
    {
        public int x0 = 0;
        public int y0 = 0;
        public Tycha(int x, int y)
        {
            Random random = new Random();
            this.x0 = x;
            this.y0 = y;
        }
    }
}

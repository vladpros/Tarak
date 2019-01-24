using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarak
{
    class Tarak
    {
        Random _rand = new Random();

        private int speed = 0;
        public int i = 0;

        public Tarak()
        {
            speed = _rand.Next(1,10);
        }

        public int Move()
        {

            return speed;
        }
    }
}

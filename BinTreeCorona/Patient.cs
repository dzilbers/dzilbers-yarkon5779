using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTreeCorona
{
    class Patient
    {
        private int id { get; set; }
        private bool dead { get; set; }

        public int GetId()
        {
            return id;
        }
        public bool GetDead()
        {
            return dead;
        }
    }
}

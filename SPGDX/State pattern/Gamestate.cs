using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    abstract internal class Gamestate
    {
        protected Game parentstate;

        public Gamestate(Game game) { parentstate= game; }

        abstract public void Decision1();

        abstract public void Decision2();

        abstract public void Decision3();

        abstract public void Decision4();

        abstract public void Decision5();

    }
}

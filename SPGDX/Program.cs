using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            Keyboard keyboard = new Keyboard(game);
            keyboard.Operate();

        }
    }
}
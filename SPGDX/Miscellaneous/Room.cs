using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX.Miscellaneous
{
    internal class Room
    {
        Random rnd = new Random(); 

        public string Type { get; set; }

        public int DiceRoll()
        {
            return rnd.Next(0, 101);
        }

        public Room()
        {
            int x = DiceRoll();

            if (x <= 40)
            {
                this.Type = "duel";
            }
            else if (x > 40 && x <= 60)
            {
                this.Type = "encounter";
            }
            else if (x > 60 && x <= 80)
            {
                this.Type = "shop";
            }
            else
            {
                this.Type = "camp";
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class NPC
    {
        protected Random rnd = new Random();

        protected Game game;

        public NPC(Game game) { this.game = game; }

        public virtual void Reward()
        {

            game.Champion.AD += rnd.Next(-15, 25);
            game.Champion.HP += rnd.Next(0, 25);
            game.Champion.CritChance += rnd.Next(-5, 10);
            game.Champion.Evasiveness += rnd.Next(-10, 15);
            game.Gold += rnd.Next(25, 50);

        }

    }
}

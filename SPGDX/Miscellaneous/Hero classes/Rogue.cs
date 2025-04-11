using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Rogue : Hero
    {
        public Rogue(Game game) : base(game) { this.AD = 70; this.HP = 700; this.Evasiveness = 45; this.CritChance = 35; }

        public override void Ability()
        {
            //reflection attack
            game.CurrentEnemy.HP -= game.CurrentEnemy.AD;
            game.CurrentEnemy.HP -= this.AD;
        }
    }
}

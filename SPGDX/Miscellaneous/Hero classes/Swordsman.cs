using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Swordsman : Hero
    {
        public Swordsman(Game game) : base(game) { this.AD = 200; this.HP = 700; this.Evasiveness = 15; this.CritChance = 5; }

        public override void Ability()
        {
            //one turn AD buff
            this.AD += 75;
            game.CurrentEnemy.Attack();
            this.AD -= 75;
        }
    }
}

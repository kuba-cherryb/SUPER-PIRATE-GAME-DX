using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Gunslinger : Hero
    {
        public Gunslinger(Game game) : base(game) { this.AD = 80; this.HP = 1250; this.Evasiveness = 20; this.CritChance = 45; }

        public override void Ability()
        {
            // guaranteed crit attack
            this.CritChance += 100;
            game.CurrentEnemy.Attack();
            this.CritChance -= 100;

        }
    }
}

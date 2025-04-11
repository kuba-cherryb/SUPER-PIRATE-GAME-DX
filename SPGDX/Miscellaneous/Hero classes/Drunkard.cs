using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Drunkard : Hero
    {
        public Drunkard(Game game) : base(game) { this.AD = 75; this.HP = 2000; this.Evasiveness = 10; this.CritChance = 5; }

        public override void Ability()
        {
            //debuff enemy AD
            game.CurrentEnemy.AD *= (3/ 4);
            this.HP -= game.CurrentEnemy.AD;
            
        }
    }
}

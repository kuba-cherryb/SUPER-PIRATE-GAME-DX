using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Captain : Hero
    {
        public Captain(Game game) : base(game) { this.AD = 100; this.HP = 1000; this.Evasiveness = 20; this.CritChance = 10; }

        public override void Ability()
        {
            //attack twice
            game.CurrentEnemy.HP -= this.AD;
            game.CurrentEnemy.Attack();

        }

    }
}

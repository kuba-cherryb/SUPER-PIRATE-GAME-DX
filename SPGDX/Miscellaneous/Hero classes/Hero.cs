using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    abstract internal class Hero
    {
        public int AD { get; set; }

        public int HP { get; set; }

        public int Evasiveness { get; set; }

        public int CritChance { get; set; }

        protected Game game;
        public Hero(Game game) 
        {
            this.game = game;
            this.AD = 777; 
            this.HP = 777; 
            this.Evasiveness = 777; 
            this.CritChance = 777; 
        }

        public virtual void Ability() { }


    }
}

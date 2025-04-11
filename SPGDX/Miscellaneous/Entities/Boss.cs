using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Boss : Enemy
    {
        public Boss(Game game) : base(game) { this.AD = rnd.Next(40, 71); this.HP = rnd.Next(1000, 1500); }

        public void Ability()
        {
            this.AD *= 2;
            game.Champion.Evasiveness /= 2;
            game.Champion.CritChance *= (3 / 4);

        }


        public override void Attack()
        {
            int ability = DiceRoll();

            if (ability <= 30)
            {
                
                this.Ability();
                Console.Clear();
                Console.WriteLine(@"








                           ____  ____  __________    __  _____   _____    __  _______ __________ 
                          / __ )/ __ \/ ___/ ___/   / / / /   | / ___/   / / / / ___// ____/ __ \
                         / __  / / / /\__ \\__ \   / /_/ / /| | \__ \   / / / /\__ \/ __/ / / / /
                        / /_/ / /_/ /___/ /__/ /  / __  / ___ |___/ /  / /_/ /___/ / /___/ /_/ / 
                      _/_____/\____//____/____/_ /_/ /_/_/  |_/____/___\____//____/_____/_____/  
                     /_  __/ / / / ____/  _/ __ \   /   |  / __ )/  _/ /   /  _/_  __/\ \/ / /   
                      / / / /_/ / __/  / // /_/ /  / /| | / __  |/ // /    / /  / /    \  / /    
                     / / / __  / /____/ // _, _/  / ___ |/ /_/ // // /____/ /  / /     / /_/     
                    /_/ /_/ /_/_____/___/_/ |_|  /_/  |_/_____/___/_____/___/ /_/     /_(_)      
                                                                             
");
                Thread.Sleep(2000);
                game.UI.Duel(0);
            }

            base.Attack();

        }

    }
}

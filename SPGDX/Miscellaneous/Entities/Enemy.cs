using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Enemy : NPC
    {
        public int AD { get; set; }

        public int HP { get; set; }

        public int MaxHP { get; set; }

        public Enemy(Game game) : base(game) { this.AD = rnd.Next(20, 51); this.HP = rnd.Next(200, 501); this.MaxHP = this.HP; }


        protected int DiceRoll()
        {
            return rnd.Next(0, 101);
        }

        public virtual void Attack()
        {
            int evade = DiceRoll();
            int crit = DiceRoll();

            if (crit <= game.Champion.CritChance && crit < 50)
            {
                Console.Clear();
                Console.WriteLine(@"









                                   ______     _ __  _            __   __  ___ __  __
                                  / ____/____(_) /_(_)________ _/ /  / / / (_) /_/ /
                                 / /   / ___/ / __/ / ___/ __ `/ /  / /_/ / / __/ / 
                                / /___/ /  / / /_/ / /__/ /_/ / /  / __  / / /_/_/  
                                \____/_/  /_/\__/_/\___/\__,_/_/  /_/ /_/_/\__(_)   
                                                      
");
                Thread.Sleep(2000);
                this.HP = this.HP - (game.Champion.AD * 3);
            }
            else
            {
                this.HP = this.HP - game.Champion.AD;
            }

            if (evade <= game.Champion.Evasiveness && evade < 50)
            {

                //evasion print
                Console.Clear();
                Console.WriteLine(@"









                            ___   __  __             __      ______                __         ____
                           /   | / /_/ /_____ ______/ /__   / ____/   ______ _____/ /__  ____/ / /
                          / /| |/ __/ __/ __ `/ ___/ //_/  / __/ | | / / __ `/ __  / _ \/ __  / / 
                         / ___ / /_/ /_/ /_/ / /__/ ,<    / /___ | |/ / /_/ / /_/ /  __/ /_/ /_/  
                        /_/  |_\__/\__/\__,_/\___/_/|_|  /_____/ |___/\__,_/\__,_/\___/\__,_(_)   
");
                Thread.Sleep(2000);
                game.UI.Duel(0);
            }
            else
            {
                game.Champion.HP = game.Champion.HP - this.AD;
            }

        }

        public override void Reward()
        {
            game.Champion.AD += rnd.Next(0, 20);
            game.Champion.HP += rnd.Next(0, 40);
            game.Champion.CritChance += rnd.Next(0, 10);
            game.Champion.Evasiveness += rnd.Next(0, 15);
            game.Gold += rnd.Next(50, 100);
        }

        public void Spare()
        {
            Console.Clear();
            Console.WriteLine(@"





                
                    

                                                        
                       ______                              _____ ____  ___    ____  __________  __      
                      / ____/___  ___  ____ ___  __  __   / ___// __ \/   |  / __ \/ ____/ __ \/ /
                     / __/ / __ \/ _ \/ __ `__ \/ / / /   \__ \/ /_/ / /| | / /_/ / __/ / / / / / 
                    / /___/ / / /  __/ / / / / / /_/ /   ___/ / ____/ ___ |/ _, _/ /___/ /_/ /_/  
                   /_____/_/ /_/\___/_/ /_/ /_/\__, /   /____/_/   /_/  |_/_/ |_/_____/_____(_)   
                                              /____/                                              
                                                                                
                                                           
                                                      
");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine(@"





                
                    

                                                             ____                                   __      
           _________  ____ ___  ___     _________ ___  __   / __/___  ___  _____   ____ ___  ____ _/ /_____ 
          / ___/ __ \/ __ `__ \/ _ \   / ___/ __ `/ / / /  / /_/ __ \/ _ \/ ___/  / __ `__ \/ __ `/ //_/ _ \
         (__  ) /_/ / / / / / /  __/  (__  ) /_/ / /_/ /  / __/ /_/ /  __(__  )  / / / / / / /_/ / ,< /  __/
        /____/\____/_/ /_/ /_/\___/  /____/\__,_/\__, /  /_/  \____/\___/____/  /_/ /_/ /_/\__,_/_/|_|\___/ 
                   __  __            __         /____/_     ____     _                __                    
                  / /_/ /_  ___     / /_  ___  _____/ /_   / __/____(_)__  ____  ____/ /____                
                 / __/ __ \/ _ \   / __ \/ _ \/ ___/ __/  / /_/ ___/ / _ \/ __ \/ __  / ___/                
                / /_/ / / /  __/  / /_/ /  __(__  ) /_   / __/ /  / /  __/ / / / /_/ (__  )                 
                \__/_/ /_/\___/  /_.___/\___/____/\__/  /_/ /_/  /_/\___/_/ /_/\__,_/____/                  
                                                                                                            
                                                                                
                                                           
                                                      
");
            Thread.Sleep(3000);

            game.Champion.AD += this.AD;
            game.Champion.HP += this.HP;
            Reward();

        }

    }
}

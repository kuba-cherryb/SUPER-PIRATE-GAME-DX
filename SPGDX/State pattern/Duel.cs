using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Duel : Gamestate
    {

        private Enemy enemy;

        private int abilityCD;

        public Duel(Game game) : base(game) 
        { 
            if (parentstate.RoomNo >= 10)
            {
                enemy = new Boss(parentstate);
                parentstate.CurrentEnemy = enemy;
            }
            else
            {
                enemy = new Enemy(parentstate);
                parentstate.CurrentEnemy = enemy;
            }
        }

        public override void Decision1()
        {
            //attack            
            this.abilityCD -= 1;
            enemy.Attack();
            parentstate.UI.Duel(0);

            if (parentstate.Champion.HP <= 0)
            {
                //print game over
                Console.Clear();
                Console.WriteLine(@"








                                                        
                                 _________    __  _________   ____ _    ____________  __
                                / ____/   |  /  |/  / ____/  / __ \ |  / / ____/ __ \/ /
                               / / __/ /| | / /|_/ / __/    / / / / | / / __/ / /_/ / / 
                              / /_/ / ___ |/ /  / / /___   / /_/ /| |/ / /___/ _, _/_/  
                              \____/_/  |_/_/  /_/_____/   \____/ |___/_____/_/ |_(_)   
                                                           
                                                      
");
                Thread.Sleep(3000);
                parentstate.ChangeState(new Menu(this.parentstate));
            }

            if (enemy.HP <= 0)
            {
                //print defeated 
                if (enemy.GetType() == typeof(Boss))
                {
                    Console.Clear();
                    Console.WriteLine(@"








                                                        
                        ____  ____  __________    ____  _____________________  ________________  __
                       / __ )/ __ \/ ___/ ___/   / __ \/ ____/ ____/ ____/   |/_  __/ ____/ __ \/ /
                      / __  / / / /\__ \\__ \   / / / / __/ / /_  / __/ / /| | / / / __/ / / / / / 
                     / /_/ / /_/ /___/ /__/ /  / /_/ / /___/ __/ / /___/ ___ |/ / / /___/ /_/ /_/  
                    /_____/\____//____/____/  /_____/_____/_/   /_____/_/  |_/_/ /_____/_____(_)   
                                                                                
                                                           
                                                      
");
                    Thread.Sleep(3000);
                    parentstate.ChangeState(new Treasure(this.parentstate));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(@"






                    

                                                        
                  ______                              ____  _____________________  ________________  __
                 / ____/___  ___  ____ ___  __  __   / __ \/ ____/ ____/ ____/   |/_  __/ ____/ __ \/ /
                / __/ / __ \/ _ \/ __ `__ \/ / / /  / / / / __/ / /_  / __/ / /| | / / / __/ / / / / / 
               / /___/ / / /  __/ / / / / / /_/ /  / /_/ / /___/ __/ / /___/ ___ |/ / / /___/ /_/ /_/  
              /_____/_/ /_/\___/_/ /_/ /_/\__, /  /_____/_____/_/   /_____/_/  |_/_/ /_____/_____(_)   
                                         /____/                                                        
                                                                                
                                                           
                                                      
");
                    Thread.Sleep(3000);
                    enemy.Reward();
                    parentstate.UI.AcceptReward();
                    parentstate.ChangeState(new Encounter(this.parentstate));
                }
            }
        }

        public override void Decision2()
        {
            //item
            if (parentstate.Item.Type != "heal" && parentstate.Item.Type != "hurt")
            {
                parentstate.UI.NoItem();
            }
            else
            {
                parentstate.Item.Use();
            }
            parentstate.UI.Duel(0);
        }

        public override void Decision3()
        {
            //ability


            if (abilityCD <= 0)
            {
                parentstate.UI.Ability();
                parentstate.Champion.Ability();
                this.abilityCD = 3;
            }
            else
            {
                //cd information print
                Console.Clear();
                Console.WriteLine(@"






                                                    ___    __    _ ___ __                     
                                                   /   |  / /_  (_) (_) /___  __   ____  ____ 
                                                  / /| | / __ \/ / / / __/ / / /  / __ \/ __ \
                                                 / ___ |/ /_/ / / / / /_/ /_/ /  / /_/ / / / /
                                                /_/  |_/_.___/_/_/_/\__/\__, /   \____/_/ /_/ 
                                                                    __ /____/                 
                                                  _________  ____  / /___/ /___ _      ______ 
                                                 / ___/ __ \/ __ \/ / __  / __ \ | /| / / __ \
                                                / /__/ /_/ / /_/ / / /_/ / /_/ / |/ |/ / / / /
                                                \___/\____/\____/_/\__,_/\____/|__/|__/_/ /_/ 
                                              
");
                Thread.Sleep(1500);
                parentstate.UI.Duel(0);

            }

        }

        public override void Decision4()
        {
            //spare
            //if hp < 50, and not boss, can spare and add dmg + hp to champion
            if (enemy.HP <= 50 && enemy.GetType() != typeof(Boss))
            {
                enemy.Spare();
                parentstate.RoomNo += 1;
                parentstate.ChangeState(new Dungeon(this.parentstate));
            }
            else
            {
                Console.Clear();
                Console.WriteLine(@"



                        ________                                                                _         
                       /  _/ __/  __  ______  __  _______   ___  ____  ___  ____ ___  __  __   (_)____    
                       / // /_   / / / / __ \/ / / / ___/  / _ \/ __ \/ _ \/ __ `__ \/ / / /  / / ___/    
                     _/ // __/  / /_/ / /_/ / /_/ / /     /  __/ / / /  __/ / / / / / /_/ /  / (__  )     
                    /___/_/     \__, /\____/\__,_/_/      \___/_/ /_/\___/_/ /_/ /_/\__, /  /_/____/      
                       / /___ _/____/__   ___  ____  ____  __  ______ _/ /_       _/____/___  __  __      
                      / / __ \ | /| / /  / _ \/ __ \/ __ \/ / / / __ `/ __ \     / / / / __ \/ / / /      
                     / / /_/ / |/ |/ /  /  __/ / / / /_/ / /_/ / /_/ / / / /    / /_/ / /_/ / /_/ /       
                    /_/\____/|__/|__/   \___/_/ /_/\____/\__,_/\__, /_/ /_(_)__ \__, /\____/\__,_/__      
                      _________ _____     _________  ____ ____/____/    / /_/ //____/  ____ ___  / /      
                     / ___/ __ `/ __ \   / ___/ __ \/ __ `/ ___/ _ \   / __/ __ \/ _ \/ __ `__ \/ /       
                    / /__/ /_/ / / / /  (__  ) /_/ / /_/ / /  /  __/  / /_/ / / /  __/ / / / / /_/        
                    \___/\__,_/_/ /_/  /____/ .___/\__,_/_/__ \___/   \__/_/ /_/\___/_/ /_/ /_(_)         
                            _/_/  / /   ___/_/_________   / /_  / /___  ____  ____/ /  | |                
                           / /   / /   / _ \/ ___/ ___/  / __ \/ / __ \/ __ \/ __  /   / /                
                          / /   / /___/  __(__  |__  )  / /_/ / / /_/ / /_/ / /_/ /   / /                 
                         / /   /_____/\___/____/____/  /_.___/_/\____/\____/\__,_/  _/_/                  
                         |_|                                                       /_/                    
");
                Thread.Sleep(2000);
                parentstate.UI.Duel(0);
            }

        }

        public override void Decision5()
        {
            //null
        }

    }
}

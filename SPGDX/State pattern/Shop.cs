using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SPGDX
{
    internal class Shop : Gamestate
    {
        public Shop(Game game) : base(game) { this.ShopItem = new Item(game); }

        public Item ShopItem;

        public override void Decision1()
        {
            //buy item

            if (parentstate.Gold >= ShopItem.Price)
            {
                parentstate.Item = ShopItem;
                parentstate.Gold = parentstate.Gold - ShopItem.Price;
            }

        }

        public override void Decision2()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            parentstate.UI.ChampionHP();
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            parentstate.UI.ChampionHP();
            Thread.Sleep(1500);
            //buy healing
            if (parentstate.Champion.GetType() == typeof(Captain) && parentstate.Gold >= 70)
            {
                parentstate.Champion.HP = 1000;
                parentstate.Gold = parentstate.Gold - 70;
            }
            else if (parentstate.Champion.GetType() == typeof(Swordsman) && parentstate.Gold >= 70)
            {
                parentstate.Champion.HP = 700;
                parentstate.Gold = parentstate.Gold - 70;
            }
            else if (parentstate.Champion.GetType() == typeof(Drunkard) && parentstate.Gold >= 70)
            {
                parentstate.Champion.HP = 2000;
                parentstate.Gold = parentstate.Gold - 70;
            }
            else if (parentstate.Champion.GetType() == typeof(Gunslinger) && parentstate.Gold >= 70)
            {
                parentstate.Champion.HP = 1250;
                parentstate.Gold = parentstate.Gold - 70;
            }
            else if (parentstate.Champion.GetType() == typeof(Rogue) && parentstate.Gold >= 70)
            {
                parentstate.Champion.HP = 700;
                parentstate.Gold = parentstate.Gold - 70;
            }
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            parentstate.UI.ChampionHP();
            Thread.Sleep(1500);
            parentstate.UI.Shop(0);

        }

        public override void Decision3()
        {
            //talk to the shopkeeper
            Console.Clear();
            Console.WriteLine(@"  







                      _   _              _          __                _           _           
                     | |_| |_  __ _ _ _ | |__ ___  / _|___ _ _   _ __| |__ _ _  _(_)_ _  __ _ 
                     |  _| ' \/ _` | ' \| / /(_-< |  _/ _ \ '_| | '_ \ / _` | || | | ' \/ _` |
                      \__|_||_\__,_|_||_|_\_\/__/ |_| \___/_|   | .__/_\__,_|\_, |_|_||_\__, |
                                 _                  _    _      |_|          |__/    _ _|___/ 
                      _ __  __ _| |_ ___    __ __ _(_)__| |_    _  _ ___ _  _   __ _| | |     
                     | '  \/ _` |  _/ -_)_  \ V  V / (_-< ' \  | || / _ \ || | / _` | | |     
                     |_|_|_\__,_|\__\___( )  \_/\_/|_/__/_||_|  \_, \___/\_,_| \__,_|_|_|     
                     | |_| |_  ___  | |_|/ ___ __| |_  __ ______|__/___                       
                     |  _| ' \/ -_) | '_ \/ -_|_-<  _| \ \ / _ \ \ / _ \                      
                      \__|_||_\___| |_.__/\___/__/\__| /_\_\___/_\_\___/                      
                                                                            
                                                                     ");
            Thread.Sleep(3000);
            parentstate.UI.Shop(0);
        }

        public override void Decision4()
        {
            //exit
            if (parentstate.RoomNo == -1)
            {
                parentstate.ChangeState(new Overworld(this.parentstate));
            }
            else
            {
                parentstate.RoomNo += 1;
                parentstate.ChangeState(new Dungeon(this.parentstate));
            }
        }

        public override void Decision5()
        {
            //null option(?)
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Treasure : Gamestate
    {
        public Treasure(Game game) : base(game) { }

        public override void Decision1()
        {
            //continue to overworld
            parentstate.RoomNo = -1;
            parentstate.ChangeState(new Overworld(this.parentstate));
        }

        public override void Decision2()
        {
            //exit to menu
            Console.Clear();
            Console.WriteLine(@"







                _   _              _                      __                _           _           _       
               | |_| |_  __ _ _ _ | |__  _  _ ___ _  _   / _|___ _ _   _ __| |__ _ _  _(_)_ _  __ _| |      
               |  _| ' \/ _` | ' \| / / | || / _ \ || | |  _/ _ \ '_| | '_ \ / _` | || | | ' \/ _` |_|      
                \__|_||_\__,_|_||_|_\_\  \_, \___/\_,_| |_| \___/_|   | .__/_\__,_|\_, |_|_||_\__, (_) _    
             __ _ _ __ _ __ _ _ ___ __(_)_|__/ |_ ___   _  _ ___ _  _  |_|_____ _ _ |__/   _ __|___/ __| |_  
            / _` | '_ \ '_ \ '_/ -_) _| / _` |  _/ -_) | || / _ \ || | \ V / -_) '_| || | | '  \ || / _| ' \ 
            \__,_| .__/ .__/_| \___\__|_\__,_|\__\___|  \_, \___/\_,_|  \_/\___|_|  \_, | |_|_|_\_,_\__|_||_|
                 |_|  |_|                               |__/                        |__/                     
");
            Thread.Sleep(2500);

            parentstate.RoomNo = -1;
            parentstate.Gold = 0;
            parentstate.Champion = new Captain(parentstate);
            parentstate.Item = new Item(parentstate, "undefined", 0);
            parentstate.ChangeState(new Menu(this.parentstate));
        }

        public override void Decision3()
        {
            //tbi
        }

        public override void Decision4()
        {
            //tbi
        }

        public override void Decision5()
        {
            //null
        }
    }
}

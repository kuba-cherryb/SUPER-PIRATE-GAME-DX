using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Camp : Gamestate
    {
        public Camp(Game game) : base(game) { }

        public override void Decision1()
        {
            //rest (heal, stat boost)
            parentstate.Champion.HP -= 300;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            parentstate.UI.ChampionHP();
            Thread.Sleep(1500);
            parentstate.Champion.HP += 777;
            parentstate.Champion.Evasiveness += 20;
            parentstate.UI.CampDecision(0);
            parentstate.RoomNo += 1;
            parentstate.ChangeState(new Dungeon(this.parentstate));
        }

        public override void Decision2()
        {
            //prepare weapon(stat boost)
            parentstate.Champion.AD += 77;
            parentstate.Champion.CritChance += 20;
            parentstate.UI.CampDecision(1);
            parentstate.RoomNo += 1;
            parentstate.ChangeState(new Dungeon(this.parentstate));
        }

        public override void Decision3()
        {
            //craft item
            parentstate.Item = new Item(parentstate);
            parentstate.RoomNo += 1;
            parentstate.UI.CampDecision(2);
            parentstate.ChangeState(new Dungeon(this.parentstate));
        }

        public override void Decision4()
        {
            //escape -> overworld
            parentstate.RoomNo = -1;
            parentstate.ChangeState(new Overworld(this.parentstate));
        }

        public override void Decision5()
        {
            //null option(?)
        }

        //you can only do one thing in the camp
        
    }
}

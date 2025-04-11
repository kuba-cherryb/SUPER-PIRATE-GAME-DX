using SPGDX.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Dungeon : Gamestate
    {
        public Dungeon(Game game) : base(game) { this.nextRoom = new Room(); }

        private Room nextRoom;

        public int RoomCount { get; set; }

        public override void Decision1()
        {
            //proceed
            if (nextRoom.Type == "duel" || parentstate.RoomNo == 10)
            {
                parentstate.ChangeState(new Duel(this.parentstate));
            }
            else if (nextRoom.Type == "encounter")
            {
                parentstate.ChangeState(new Encounter(this.parentstate));
            }
            else if (nextRoom.Type == "shop")
            {
                Shop x = new Shop(this.parentstate);
                parentstate.ShopItem = x.ShopItem;
                parentstate.ChangeState(x);
            }
            else if (nextRoom.Type == "camp")
            {
                parentstate.ChangeState(new Camp(this.parentstate));
            }

        }

        public override void Decision2()
        {
            //eq option
            parentstate.ChangeState(new Equipment(this.parentstate));

        }

        public override void Decision3()
        {
            //"run" option
            parentstate.RoomNo = -1;
            parentstate.ChangeState(new Overworld(this.parentstate));

        }

        public override void Decision4()
        {
            //quit to menu option
            parentstate.RoomNo = -1;
            parentstate.Gold = 0;
            parentstate.Champion = new Captain(parentstate);
            parentstate.Item = new Item(parentstate, "undefined", 0);
            parentstate.ChangeState(new Menu(this.parentstate));

        }

        public override void Decision5()
        {
            //null
        }

    }
}

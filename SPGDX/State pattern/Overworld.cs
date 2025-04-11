using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Overworld : Gamestate
    {
        public Overworld(Game game) : base(game) { }

        public override void Decision1()
        {
            //ow -> dgn 
            parentstate.RoomNo = 1;
            parentstate.UI.DungeonStory();
            parentstate.ChangeState(new Dungeon(this.parentstate));
        }

        public override void Decision2()
        {
            //ow -> shop
            Shop x = new Shop(this.parentstate);
            parentstate.ShopItem = x.ShopItem;
            parentstate.ChangeState(x);
        }

        public override void Decision3()
        {
            //ow -> eq
            parentstate.ChangeState(new Equipment(this.parentstate));
        }

        public override void Decision4()
        {
            //ow -> menu
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

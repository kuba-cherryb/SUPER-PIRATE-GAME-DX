using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Equipment : Gamestate
    {
        public Equipment(Game game) : base(game) { }

        public override void Decision1()
        {
            //use item
            if (parentstate.Item.Type == "heal")
            {
                parentstate.UI.HealingItem();
                parentstate.UI.Equipment(0);
            }
            else
            {
                //print unable to use item
                parentstate.UI.NoItem();
                parentstate.UI.Equipment(0);
            }
        }

        public override void Decision2()
        {
            //exit
            if (parentstate.RoomNo == -1)
            {
                parentstate.ChangeState(new Overworld(this.parentstate));
            }
            else
            {
                parentstate.ChangeState(new Dungeon(this.parentstate));
            }
        }

        public override void Decision3()
        {
            //null
        }

        public override void Decision4()
        {
            //null
        }

        public override void Decision5()
        {
            //null
        }

    }
}

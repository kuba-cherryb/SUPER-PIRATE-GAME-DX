using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Encounter : Gamestate
    {
        public Encounter(Game game) : base(game) { this.entity = new NPC(parentstate); }

        private NPC entity;

        public override void Decision1()
        {
            //accept offer
            entity.Reward();
            parentstate.UI.AcceptReward();
            parentstate.RoomNo += 1;
            parentstate.ChangeState(new Dungeon(this.parentstate));
        }

        public override void Decision2()
        {
            //use item
            if (parentstate.Item.Type == "heal")
            {
                parentstate.UI.HealingItem();
                parentstate.RoomNo += 1;
                parentstate.ChangeState(new Dungeon(this.parentstate));
            }
            else
            {
                //print unable to use item
                parentstate.UI.NoItem();
                parentstate.UI.Encounter(0);
            }
        }

        public override void Decision3()
        {
            //abandon entity
            parentstate.RoomNo += 1;
            parentstate.ChangeState(new Dungeon(this.parentstate));
        }

        public override void Decision4()
        {
            //null
        }

        public override void Decision5()
        {
            //null
        }

        //encounter shall work as a "reward place" as a stand alone room, or a buffor place between dungeon and duel
    }
}

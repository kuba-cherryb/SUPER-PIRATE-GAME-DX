using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class ChampSelect : Gamestate
    {
        public ChampSelect(Game game) : base(game) { }

        public override void Decision1()
        {
            //cap'n class -> overworld
            parentstate.Champion = new Captain(parentstate);
            parentstate.ChangeState(new Overworld(this.parentstate));
            parentstate.UI.OverworldStory();

        }

        public override void Decision2()
        {
            //S-man -> ow
            parentstate.Champion = new Swordsman(parentstate);
            parentstate.ChangeState(new Overworld(this.parentstate));
            parentstate.UI.OverworldStory();

        }

        public override void Decision3()
        {
            //dkrd -> ow
            parentstate.Champion = new Drunkard(parentstate);
            parentstate.ChangeState(new Overworld(this.parentstate));
            parentstate.UI.OverworldStory();

        }

        public override void Decision4()
        {
            //gslgr -> ow
            parentstate.Champion = new Gunslinger(parentstate);
            parentstate.ChangeState(new Overworld(this.parentstate));
            parentstate.UI.OverworldStory();

        }

        public override void Decision5()
        {
            //rge -> ow
            parentstate.Champion = new Rogue(parentstate);
            parentstate.ChangeState(new Overworld(this.parentstate));
            parentstate.UI.OverworldStory();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Menu : Gamestate
    {
        public Menu(Game game) : base(game) { }

        public override void Decision1()
        {
            //new game -> champ select
            parentstate.ChangeState(new ChampSelect(this.parentstate));
        }

        public override void Decision2()
        {
            //how to play
            parentstate.UI.H2P();
        }

        public override void Decision3()
        {
            //credits
            parentstate.UI.Credits();

        }

        public override void Decision4()
        {
            //quit
            Environment.Exit(0);

        }

        public override void Decision5()
        {
            //null option(?)
        }

    }
}

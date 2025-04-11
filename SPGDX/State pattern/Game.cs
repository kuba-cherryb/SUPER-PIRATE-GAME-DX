using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Game
    {

        public Hero Champion { get; set; }

        public int Gold { get; set; }

        public int RoomNo { get; set; }

        public Item Item { get; set; }

        public Enemy CurrentEnemy { get; set; }

        public Gamestate CurrentState { get; set; }

        public Item ShopItem { get; set; }

        public GUI UI { get; set; }

        public Game()
        {
            this.CurrentState = new Menu(this);
            this.Gold = 0;
            this.Item = new Item(this, "undefined", 0);
            this.Champion = new Captain(this);
            this.CurrentEnemy = new Enemy(this);
            this.RoomNo = -1;
            this.UI = new GUI(this);
        }

        public void ChangeState(Gamestate newState)
        {
            CurrentState = newState;
        }

        public void Position1()
        {
            CurrentState.Decision1();
        }

        public void Position2()
        {
            CurrentState.Decision2();
        }

        public void Position3()
        {
            CurrentState.Decision3();
        }

        public void Position4()
        {
            CurrentState.Decision4();
        }

        public void Position5()
        {
            CurrentState.Decision5();
        }

    }
}

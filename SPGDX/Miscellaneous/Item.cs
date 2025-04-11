using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Item
    {
        Random rnd = new Random();

        private Game game;
        public string Type { get; set; }

        public int Price { get; set; }

        public int Value { get; set; }

        private int DiceRoll()
        {
            return rnd.Next(0, 100);
        }

        public Item(Game game)
        {

            this.game = game;

            int x = DiceRoll();

            this.Price = x;

            this.Value = x;

            if (x >= 50)
            {
                this.Type = "heal";
            }
            else
            {
                this.Type = "hurt";
            }

        }

        public Item(Game game, string type, int value)
        {
            this.game = game;
            this.Type = type;
            this.Value = value;
            this.Price = 0;
        }

        public void Use()
        {
            //use item
            if (this.Type == "heal")
            {
                game.Champion.HP +=  5 * this.Value;
            }
            else if (this.Type == "hurt")
            {
                game.CurrentEnemy.HP -= this.Value;
            }
            game.Item = new Item(game, "undefined", 0);
        }

    }
}

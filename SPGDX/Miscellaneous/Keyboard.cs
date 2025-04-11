using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SPGDX
{
    internal class Keyboard
    {
        public int position;
        private Game game;
        public Keyboard(Game game) { this.position = 0; this.game = game; }

        public void Operate()
        {

            EnterState();

            while (true)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);   

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Type x = game.CurrentState.GetType();
                    if (position == 0) { game.Position1(); } 
                    else if (position == 1) { game.Position2(); }
                    else if (position == 2) { game.Position3(); }
                    else if (position == 3) { game.Position4(); }
                    else if (position == 4) { game.Position5(); }
                    Type y = game.CurrentState.GetType();
                    position = 0;
                    if (x != y)
                    {
                        EnterState();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.A)
                {
                    PositionChange(-1);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.D)
                {
                    PositionChange(1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.S)
                {
                    PositionChange(-1);
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.W)
                {
                    PositionChange(1);
                }

            }
        }

        public void PositionChange(int posneg)
        {
            if (State() == "Menu")
            {
                if (posneg == -1 && position == 0) { position = 3; }
                else { position = (position + posneg) % 4; }
                game.UI.Menu(position);
            }
            else if (State() == "ChampSelect")
            {
                if (posneg == -1 && position == 0) { position = 4; }
                else { position = (position + posneg) % 5; }
                game.UI.ChampSelect(position);
            }
            else if (State() == "Overworld")
            {
                if (posneg == -1 && position == 0) { position = 3; }
                else { position = (position + posneg) % 4; }
                game.UI.Overworld(position);
            }
            else if (State() == "Dungeon")
            {
                if (posneg == -1 && position == 0) { position = 3; }
                else { position = (position + posneg) % 4; }
                game.UI.Dungeon(position);
            }
            else if (State() == "Shop")
            {
                if (posneg == -1 && position == 0) { position = 3; }
                else { position = (position + posneg) % 4; }
                game.UI.Shop(position);
            }
            else if (State() == "Equipment")
            {
                if (posneg == -1 && position == 0) { position = 1; }
                else { position = (position + posneg) % 2; }
                game.UI.Equipment(position);
            }
            else if (State() == "Encounter")
            {
                if (posneg == -1 && position == 0) { position = 2; }
                else{ position = (position + posneg) % 3; }
                game.UI.Encounter(position);
            }
            else if (State() == "Duel")
            {
                if (posneg == -1 && position == 0) { position = 3; }
                else { position = (position + posneg) % 4; }
                game.UI.Duel(position);
            }
            else if (State() == "Camp")
            {
                if (posneg == -1 && position == 0) { position = 3; }
                else { position = (position + posneg) % 4; }
                game.UI.Camp(position);
            }
            else if (State() == "Treasure")
            {
                if (posneg == -1 && position == 0) { position = 1; }
                else { position = (position + posneg) % 2; }
                game.UI.Treasure(position);
            }



        }

        public string State()
        {
            if (game.CurrentState.GetType() == typeof(Menu)) { return "Menu"; }
            else if (game.CurrentState.GetType() == typeof(ChampSelect)) { return "ChampSelect"; }
            else if (game.CurrentState.GetType() == typeof(Overworld)) { return "Overworld"; }
            else if (game.CurrentState.GetType() == typeof(Dungeon)) { return "Dungeon"; }
            else if (game.CurrentState.GetType() == typeof(Shop)) { return "Shop"; }
            else if (game.CurrentState.GetType() == typeof(Equipment)) { return "Equipment"; }
            else if (game.CurrentState.GetType() == typeof(Encounter)) { return "Encounter"; }
            else if (game.CurrentState.GetType() == typeof(Duel)) { return "Duel"; }
            else if (game.CurrentState.GetType() == typeof(Camp)) { return "Camp"; }
            else if (game.CurrentState.GetType() == typeof(Treasure)) { return "Treasure"; }
            else { return "unknown"; }
        }

        public void EnterState()
        {
            if (State() == "Menu") { game.UI.Menu(0); }
            else if(State() == "ChampSelect") { game.UI.ChampSelect(0); }
            else if(State() == "Overworld") { game.UI.Overworld(0); }
            else if(State() == "Equipment") { game.UI.Equipment(0); }
            else if(State() == "Shop") { game.UI.Shop(0); }
            else if(State() == "Dungeon") { game.UI.Dungeon(0); }
            else if(State() == "Encounter") { game.UI.EncounterStory(); } 
            else if(State() == "Duel") { game.UI.Duel(0); }
            else if(State() == "Camp") { game.UI.CampStory(); }
            else if(State() == "Treasure") { game.UI.TreasureStory(); }
        }

    }
}

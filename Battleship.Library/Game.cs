using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class Game
    {
        public Player player    {set; get;}
        public Computer computer { set; get; }

        public int PlayerShipsLeft { get; set; }
        public int ComputerShipsLeft { get; set; }

        public Game(string name, Difficulty d)
        {
            player = new Player(name);
            computer = new Computer(d);
            PlayerShipsLeft = 5;
            ComputerShipsLeft = 5;
            
        }

        public string ComputerAttack(MyGrid g)
        {
            string value = computer.strategy.Execute(g);
            return value;
        }

    }
}

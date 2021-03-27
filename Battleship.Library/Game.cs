using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class Game
    {
        public Player player    {set; get;}
        public Computer computer { set; get; }

        public Game(string name, Difficulty d)
        {
            player = new Player(name);
            computer = new Computer(d);
            
        }


    }
}

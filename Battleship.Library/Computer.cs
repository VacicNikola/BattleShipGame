using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class Computer
    {
        public IDifficulty strategy { get; set; }

        public Difficulty D { get; set; }

        public MyGrid positionOfComputerShips { get; set; }
        public Computer(Difficulty d)
        {
            D = d;

            if (d == Difficulty.Easy)
                strategy = new Strategies.EasyStrategy();
            else if (d == Difficulty.Medium)
                strategy = new Strategies.MediumStrategy();
            else
                strategy = new Strategies.HardStrategy();

            positionOfComputerShips = new MyGrid();
        
        }

        
    }
}

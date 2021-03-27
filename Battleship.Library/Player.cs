using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class Player {

        public string Name { get; set; }

        public MyGrid positionOfMyShips { get; set; }


        public Player(string name)
        {
            this.Name = name;
            positionOfMyShips = new MyGrid();
        }

    }
}

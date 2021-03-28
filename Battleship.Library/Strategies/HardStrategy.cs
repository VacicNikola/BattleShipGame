using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library.Strategies
{
    public class HardStrategy : IDifficulty
    {
        public string Execute(MyGrid grid)
        {
            string value1, value2, value3;
            Random rnd = new Random();

            do
            {
                value1 = grid.fields[rnd.Next(0, 8)][rnd.Next(0, 8)];
                value2 = grid.fields[rnd.Next(0, 8)][rnd.Next(0, 8)];
                value3 = grid.fields[rnd.Next(0, 8)][rnd.Next(0, 8)];
                if(grid.attackedFields.Contains(value1) == false && grid.attackedFields.Contains(value2) == false && grid.attackedFields.Contains(value2) == false)
                    break;
            }
            while (true);

            if (grid.checkIfHit(value1).Item1)
            {
                foreach (var ship in grid.listOfShips)
                    if (ship.OcupiedFields.Contains(value1))
                        grid.attackedFields.AddRange(new List<string>(ship.OcupiedFields));
                return value1;
            }
            else if (grid.checkIfHit(value2).Item1)
            {
                foreach (var ship in grid.listOfShips)
                    if (ship.OcupiedFields.Contains(value2))
                        grid.attackedFields.AddRange(new List<string>(ship.OcupiedFields));
                return value2;
            }
            else if (grid.checkIfHit(value3).Item1)
            {
                foreach (var ship in grid.listOfShips)
                    if (ship.OcupiedFields.Contains(value3))
                        grid.attackedFields.AddRange(new List<string>(ship.OcupiedFields));

                return value3;
            }
            else {
                grid.attackedFields.Add(value1);
                return value1;
            }

        }
    }
}

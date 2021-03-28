using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library.Strategies
{
    public class EasyStrategy : IDifficulty
    {
        public string Execute(MyGrid grid)
        {
            Random rnd = new Random();
            string value;

            do
            {
                value = grid.fields[rnd.Next(0, 8)][rnd.Next(0, 8)];
                if (grid.attackedFields.Contains(value) == false)
                    break;
            }
            while (true);

            

            if (grid.checkIfHit(value).Item1)
            {
                foreach (var ship in grid.listOfShips)
                    if (ship.OcupiedFields.Contains(value))
                        grid.attackedFields.AddRange(new List<string>(ship.OcupiedFields));
            }
            else {
                grid.attackedFields.Add(value);
            }

            return value;

        }
    }
}

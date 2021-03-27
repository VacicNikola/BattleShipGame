using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class MyGrid
    {

        public List<Ship> listOfShips { get; set; }
        public string[][] fields;

        public MyGrid()
        {
            listOfShips = new List<Ship>() { };
            fields = new string[8][];

            for (int i = 0; i < 8; ++i)
                fields[i] = new string[8];

            string[] rows = new string[] { "1","2","3","4","5","6","7","8" };
            string[] cols = new string[] { "A","B","C","D","E","F","G","H" };

            for (int i = 0; i < rows.Length; ++i)
                for (int j = 0; j < cols.Length; ++j)
                    fields[i][j] = $"{cols[j]}{rows[i]}";

        }

        public void addShip(Ship s) {
            listOfShips.Add(s);
        }

        public bool availableLocation(List<string> fields) {


            foreach (var s in fields)
                foreach (var ship in listOfShips)
                    if (ship.OcupiedFields.Contains(s))
                        return false;

            return true;

        }

        public static string Randomize(MyGrid grid, List<Ship> list)
        {
            Random rnd = new Random();

            return $"{grid.fields[rnd.Next(1, 8)][rnd.Next(1, 8)]}";

        }
    }
}

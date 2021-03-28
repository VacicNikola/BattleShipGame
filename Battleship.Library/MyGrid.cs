using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class MyGrid
    {

        public List<Ship> listOfShips { get; set; }
        public string[][] fields;
        public List<string> attackedFields;

        public MyGrid()
        {
            listOfShips = new List<Ship>() { };
            fields = new string[8][];
            attackedFields = new List<string>();

            for (int i = 0; i < 8; ++i)
                fields[i] = new string[8];

            string[] rows = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
            string[] cols = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

            for (int i = 0; i < rows.Length; ++i)
                for (int j = 0; j < cols.Length; ++j)
                    fields[i][j] = $"{cols[j]}{rows[i]}";

        }

        public void addShip(Ship s)
        {
            listOfShips.Add(s);
        }

        public bool availableLocation(List<string> fields)
        {


            foreach (var s in fields)
                foreach (var ship in listOfShips)
                    if (ship.OcupiedFields.Contains(s))
                        return false;

            return true;

        }

        public static void Randomize(MyGrid grid, List<Ship> list)
        {
            Random rnd = new Random();
            List<string> listOfFields = new List<string> { };

            int shipCounter = 0;

            while (shipCounter < 5)
            {

                string value = $"{grid.fields[rnd.Next(0, 8)][rnd.Next(0, 8)]}";
                char[] seperateValues = value.ToCharArray();

                if (rnd.Next(100) < 50 ? true : false)
                    list[shipCounter].HorizontalOrientation = true;
                else
                    list[shipCounter].HorizontalOrientation = false;

                listOfFields.Add(value);

                if (list[shipCounter].HorizontalOrientation == true)
                {
                    for (int i = 1, k = 1; i < list[shipCounter].Length; ++i)
                    {
                        if ((seperateValues[0] + i) >= (int)'A' && (seperateValues[0] + i) <= (int)'H')
                            listOfFields.Add($"{(char)(seperateValues[0] + i)}{seperateValues[1]}");
                        else
                        {
                            listOfFields.Add($"{(char)(seperateValues[0] - k)}{seperateValues[1]}");
                            k++;
                        }
                    }

                }
                else
                {
                    for (int i = 1, k = 1; i < list[shipCounter].Length; ++i)
                    {
                        if ((seperateValues[1] + i) >= (int)'1' && (seperateValues[1] + i) <= (int)'8')
                            listOfFields.Add($"{seperateValues[0]}{(char)(seperateValues[1] + i)}");
                        else
                        {
                            listOfFields.Add($"{seperateValues[0]}{(char)(seperateValues[1] - k)}");
                            k++;
                        }

                    }

                }

                if (grid.availableLocation(listOfFields))
                {
                    list[shipCounter].OcupiedFields = new List<string>(listOfFields);
                    grid.addShip(list[shipCounter++]);
                }
                else
                {
                    listOfFields.Clear();
                }




            }


        }

        public (bool,Ship) checkIfHit(string value)
        {
            foreach (var ship in listOfShips)
            {
                foreach (var str in ship.OcupiedFields)
                {
                    if (value == str)
                        return (true, ship);
                }
            }

            return (false, null);
        }

    }
}

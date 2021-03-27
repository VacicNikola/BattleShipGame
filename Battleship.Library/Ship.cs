using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Library
{
    public class Ship
    {
        public int Length { get; set; }     // duzina broda
        public bool HorizontalOrientation { get; set; }     // orijentacija
        public List<string> OcupiedFields { get; set; }

        public string Image { get; set; }


        public Ship(int length, bool ho, List<string> of, string i)
        {
            Length = length;
            HorizontalOrientation = ho;
            OcupiedFields = of;
            Image = i;
        }




    }
}

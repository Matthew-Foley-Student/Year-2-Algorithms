/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * BattleShips
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLibrary.Models
{
    public class CellModel
    {
        public CellModel(int row, int collumn)
        {
            Row = row;
            Collumn = collumn;
            Ship = false;
            Revealed = false;
            ShipType = "";
        }

        public int Row { get; set; }
        public int Collumn { get; set; }
        public bool Ship { get; set; }
        public bool Revealed { get; set; }
        public string ShipType { get; set; }
    }
}

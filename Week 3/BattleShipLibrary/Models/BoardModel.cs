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
    public class BoardModel
    {
        public int Size { get; private set; }
        public CellModel[,] Grid { get; set; }

        public BoardModel(int size)
        {
            Size = size;
            Grid = new CellModel[Size, Size];
            InitilzeBoard();
        }
        private void InitilzeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new CellModel(i, j);
                }
            }
        }
    }
}

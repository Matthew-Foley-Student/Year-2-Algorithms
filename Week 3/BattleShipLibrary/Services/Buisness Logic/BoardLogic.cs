/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * BattleShips
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BattleShipLibrary.Models;

namespace BattleShipLibrary.Services.Buisness_Logic
{
    public class BoardLogic
    {
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            int size = board.Size;
            bool IsRowSafe = row >= 0 && row < size;
            bool IsColumnSafe = col >= 0 && col < size;
            return IsRowSafe && IsColumnSafe;
        }

        private bool CanMarkCell(BoardModel board, int row, int col)
        {
            return IsOnBoard(board, row, col)
                && board.Grid[row, col].ShipType == ""
                && !board.Grid[row, col].Ship;
        }

        public BoardModel MarkLegalLocation(BoardModel board, CellModel currentCell, string shipName)
        {
            switch (shipName.ToLower())
            {
                //The destroyer placements in the 4 cardnal directions
                case "destroyerul":
                    board = AttemptPlaceDestroyerUpLeft(board, currentCell);
                    break;
                case "destroyerur":
                    board = AttemptPlaceDestroyerUpRight(board, currentCell);
                    break;
                case "destroyerdr":
                    board = AttemptPlaceDestroyerDownRight(board, currentCell);
                    break;
                case "destroyerdl":
                    board = AttemptPlaceDestroyerDownLeft(board, currentCell);
                    break;


                //The submarines placemnt in the 4 cardnial directions
                case "submarineul":
                    board = AttemptPlaceSubmarineUpLeft(board, currentCell);
                    break;
                case "submarineur":
                    board = AttemptPlaceSubmarineUpRight(board, currentCell);
                    break;
                case "submarinedr":
                    board = AttemptPlaceSubmarineDownRight(board, currentCell);
                    break;
                case "submarinedl":
                    board = AttemptPlaceSubmarineDownLeft(board,currentCell);
                    break;


                //3 connected non diangnal
                case "cruiserul":
                    board = AttemptPlaceCruiserUpLeft(board, currentCell);
                    break;
                case "cruiserur":
                    board = AttemptPlaceCruiserUpRight(board, currentCell);
                    break;
                case "cruiserdr":
                    board = AttemptPlaceCruiserDownLeft(board, currentCell);
                    break;
                case "cruiserdl":
                    board = AttemptPlaceCruiserDownRight(board, currentCell);
                    break;


                default:
                    return board;
            }
            return board;
            
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //The 4 methods for submarine placements (3 long diagnal)
        //--------------------------------------------------------------------------------------------------------------------------------------

        private BoardModel AttemptPlaceSubmarineUpLeft(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, -1, -2 };
            int[] dC = { 0, 1, 2 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "Sul";
                    ok++;
                }
            }
            if (ok == 3) return board;

            // revert partial marks
            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "Sul")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }


        private BoardModel AttemptPlaceSubmarineUpRight(BoardModel board, CellModel currentCell)
        {

            int ok = 0;
            int[] dR = { 0, 1, 2 };
            int[] dC = { 0, 1, 2 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "Sur";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "Sur")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        private BoardModel AttemptPlaceSubmarineDownLeft(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, -1, -2 };
            int[] dC = { 0, -1, 2 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "Sdl";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "Sdl")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }


        private BoardModel AttemptPlaceSubmarineDownRight(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, 1, 2 };
            int[] dC = { 0, -1, -2 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "Sdr";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "Sdr")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }


        //--------------------------------------------------------------------------------------------------------------------------------
        //The 4 methods for the Destroyer placements (2X2 square)
        //--------------------------------------------------------------------------------------------------------------------------------
        private BoardModel AttemptPlaceDestroyerUpRight(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, 1, 1, 0 };
            int[] dC = { 0, 0, 1, 1 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "D";
                    ok++;
                }
            }
            if (ok == 4) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "D")
                    board.Grid[r, c].ShipType = "";
            }
            return board;

        }

        private BoardModel AttemptPlaceDestroyerDownLeft(BoardModel board, CellModel currentCell)
        {

            int ok = 0;
            int[] dR = { 0, -1, -1, 0 };
            int[] dC = { 0, 0, -1, -1 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "D";
                    ok++;
                }
            }
            if (ok == 4) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "D")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        private BoardModel AttemptPlaceDestroyerDownRight(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, 1, 1, 0 };
            int[] dC = { 0, 0, -1, -1 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "D"; // <- keep "D" (not "Ddr")
                    ok++;
                }
            }
            if (ok == 4) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "D")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        private BoardModel AttemptPlaceDestroyerUpLeft(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, -1, -1, 0 };
            int[] dC = { 0, 0, 1, 1 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "D";
                    ok++;
                }
            }
            if (ok == 4) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "D")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //The 4 methods for the Cruiser (3 long horizontal)
        //--------------------------------------------------------------------------------------------------------------------------------
        private BoardModel AttemptPlaceCruiserUpLeft(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, 1, 2 };
            int[] dC = { 0, 0, 0 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "C";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "C")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        private BoardModel AttemptPlaceCruiserUpRight(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, 0, 0 };
            int[] dC = { 0, 1, 2 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "C";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "C")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        private BoardModel AttemptPlaceCruiserDownRight(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, 0, 0 };
            int[] dC = { 0, -1, -2 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "C";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "C")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }

        private BoardModel AttemptPlaceCruiserDownLeft(BoardModel board, CellModel currentCell)
        {
            int ok = 0;
            int[] dR = { 0, -1, -2 };
            int[] dC = { 0, 0, 0 };

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (CanMarkCell(board, r, c))
                {
                    board.Grid[r, c].ShipType = "C";
                    ok++;
                }
            }
            if (ok == 3) return board;

            for (int i = 0; i < dR.Length; i++)
            {
                int r = currentCell.Row + dR[i];
                int c = currentCell.Collumn + dC[i];
                if (IsOnBoard(board, r, c) && board.Grid[r, c].ShipType == "C")
                    board.Grid[r, c].ShipType = "";
            }
            return board;
        }
    }
}

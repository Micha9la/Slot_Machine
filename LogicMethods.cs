using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class LogicMethods
    {
        public static bool CheckCentralLineWin(int[,] grid)
        {
            int rowLength = grid.GetLength(0);//stores the number of rows in the grid
            int columnLength = grid.GetLength(1);//stores the number of columns.
            int middleRowIndex = rowLength / Constants.GRID_DIVISOR;
            int firstElementMiddleRow = grid[middleRowIndex, 0];

            for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                if (grid[middleRowIndex, columnIndex] != firstElementMiddleRow)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckHorizontalLinesWin(int[,] grid)
        {
            int rowLength = grid.GetLength(0);//stores the number of rows in the grid
            int columnLength = grid.GetLength(1);//stores the number of columns.

            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                int firstElement = grid[rowIndex, 0];
                for (int columnIndex = 1; columnIndex < columnLength; columnIndex++)
                {
                    if (grid[rowIndex, columnIndex] != firstElement)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CheckVerticalLinesWin(int[,] grid)
        {
            int rowLength = grid.GetLength(0);//stores the number of rows in the grid
            int columnLength = grid.GetLength(1);//stores the number of columns.

            for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                int firstElement = grid[0, columnIndex];
                for (int rowIndex = 1; rowIndex < rowLength; rowIndex++)
                {
                    if (grid[rowIndex, columnIndex] != firstElement)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool CheckDiagonalLinesWin(int[,] grid)
        {
            int size = grid.GetLength(0); // Get grid size (assume square grid) number of rows

            //Check Main Diagonal (\)
            int firstMainDiagonal = grid[0, 0];
            bool mainDiagonalWin = true;
            for (int i = 1; i < size; i++)
            {
                if (grid[i, i] != firstMainDiagonal)
                {
                    mainDiagonalWin = false;
                    break;
                }
            }

            //Check Anti-Diagonal (/)
            int firstAntiDiagonal = grid[0, size - 1];
            bool antiDiagonalWin = true;
            for (int i = 1; i < size; i++)
            {
                if (grid[i, size - 1 - i] != firstAntiDiagonal)
                {
                    antiDiagonalWin = false;
                    break;
                }
            }

            return mainDiagonalWin || antiDiagonalWin;
        }

        public static double UpdateWalletBalance(double walletValidated, double wagerValidated, bool win)
        {
            if (win)
            {
                walletValidated += wagerValidated;
            }
            else
            {
                walletValidated -= wagerValidated;
            }
            return walletValidated;
        }
    }
}

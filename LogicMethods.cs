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
            return (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) ||
                    (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]);
        }
    }
}

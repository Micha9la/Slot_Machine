﻿using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int UPPER_NUMBER_RANGE = 4;
            const int LOWER_NUMBER_RANGE = 1;
            const int GRID_SIZE_ROW = 3;
            const int GRID_SIZE_COLUMN = 3;
            const string GAME_MODE_CENTRAL_LINE = "A";
            const string GAME_MODE_HORIZONTAL_LINES = "B";
            const string GAME_MODE_VERTICAL_LINES = "C";
            const string GAME_MODE_DIAGONAL_LINES = "D";
            const int GRID_DIVISOR = 2;

            Random random = new Random();
            Console.WriteLine("Welcome to the slot machine.");
            Console.WriteLine("How much would you like to wage? Please enter only a number");
            int wager = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please choose ONLY ONE of the following game mode options " +
                "and write only the coresponding symbol in capital letters: " +
                "A for central line, B for all horizontal lines, C for all vertikal lines, D for all diagonal lines");
            string gameMode = Console.ReadLine();
            string gameModeInsensitive = gameMode.ToUpper();

            int[,] grid = new int[GRID_SIZE_ROW, GRID_SIZE_COLUMN];

            for (int lineIndex = 0; lineIndex < GRID_SIZE_ROW; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < GRID_SIZE_COLUMN; columnIndex++)
                {
                    int randomNumber = random.Next(LOWER_NUMBER_RANGE, UPPER_NUMBER_RANGE);
                    grid[lineIndex, columnIndex] = randomNumber;
                    Console.Write(grid[lineIndex, columnIndex] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Above you see the grid");

            int rowLength = grid.GetLength(0);
            int middleRowIndex = rowLength / GRID_DIVISOR;
            int firstElementMiddleRow = grid[middleRowIndex, 0];

            int columnLength = grid.GetLength(1);

            if (gameModeInsensitive == GAME_MODE_CENTRAL_LINE)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    if (grid[middleRowIndex, columnIndex] != firstElementMiddleRow)
                    {
                        Console.WriteLine("You lost " + wager + " Euro");
                        return;
                    }
                }
                Console.WriteLine("You won " + wager + " Euro");
            }


            int numOfWins = 0;
            if (gameModeInsensitive == GAME_MODE_HORIZONTAL_LINES)
            {
                for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                {
                    bool win = true;
                    int firstElementOfEachRow = grid[lineIndex, 0];
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        if (grid[lineIndex, columnIndex] != firstElementOfEachRow)
                        {
                            win = false;
                            break;// Move to the next lineIndex after finding a win
                        }
                    }
                    if (win)
                    {
                        numOfWins++;
                    }
                }
                if (numOfWins > 0)
                {
                    Console.WriteLine("You won " + (wager / GRID_SIZE_ROW) * numOfWins + " Euro, because " + numOfWins + " lineIndex(s) is/are the same");
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No row is the same");
                }
            }

            if (gameModeInsensitive == GAME_MODE_VERTICAL_LINES)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    bool win = true;
                    int firstElementOfEachColumn = grid[0, columnIndex];
                    for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                    {
                        if (grid[lineIndex, columnIndex] != firstElementOfEachColumn)
                        {
                            win = false;
                            break;// Move to the next column after finding a win
                        }
                    }
                    if (win)
                    {
                        numOfWins++;
                    }
                }
                if (numOfWins > 0)
                {
                    Console.WriteLine("You won " + (wager / GRID_SIZE_COLUMN) * numOfWins + " Euro, because " + numOfWins + " column(s) is/are the same.");
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No column is the same");
                }
            }

            if (gameModeInsensitive == GAME_MODE_DIAGONAL_LINES)
            {
                for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                {
                    bool win = true;
                    int firstElementRightToLeft = grid[lineIndex, GRID_SIZE_COLUMN - 1 - lineIndex];
                    
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        if (grid[lineIndex, columnIndex] != firstElementRightToLeft)
                        {
                            win = false;
                            break;// Move to the next column after finding a win
                        }
                    }
                    if (win)
                    {
                        numOfWins++;
                    }
                }
                if (numOfWins > 0)
                {
                    Console.WriteLine("You won. You have a diagonal win from right to left.");
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No diagonal is the same.");
                }
                int numOfWinsDiagonalLeftToRight = 0;
                for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                {
                    bool win = true;                    
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        int firstElementLeftToRight = grid[lineIndex, columnIndex];
                        if (grid[lineIndex, columnIndex] != firstElementLeftToRight)
                        {
                            win = false;
                            break;// Move to the next column after finding a win
                        }
                    }
                    if (win)
                    {
                        numOfWinsDiagonalLeftToRight++;
                    }
                }
                if (numOfWinsDiagonalLeftToRight > 0)
                {
                    Console.WriteLine("You won. You have a diagonal win from left to right.");
                }
                if (numOfWinsDiagonalLeftToRight == 0)
                {
                    Console.WriteLine("You lost. No diagonal is the same.");
                }
            }

        }


    }
}

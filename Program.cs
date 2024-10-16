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

            int rows = grid.GetLength(0);
            int middleRowIndex = rows / GRID_DIVISOR;
            int firstElementMiddleRow = grid[middleRowIndex, 0];
            int columns = grid.GetLength(1);
            if (gameModeInsensitive == GAME_MODE_CENTRAL_LINE)
            {
                for (int col = 0; col < columns; col++) 
                {
   
                    if (grid[middleRowIndex, col] != firstElementMiddleRow)
                    {
                        Console.WriteLine("You lost " + wager + " Euro");
                        return;
                    }                  
                }
            }
            Console.WriteLine("You won " + wager + " Euro");

            if (gameModeInsensitive == GAME_MODE_HORIZONTAL_LINES)
            {
                int modeA = rows;
                int firstElement = grid[modeA, 0];
                int secondElement = grid[modeA, 1];
                int thirdElement = grid[modeA, 2];

                if (firstElement == secondElement && secondElement == thirdElement)
                {
                    Console.WriteLine("You won " + wager);
                }
                else
                {
                    Console.WriteLine("You lost " + wager);
                }
            }
            if (gameModeInsensitive != GAME_MODE_CENTRAL_LINE && gameModeInsensitive != GAME_MODE_HORIZONTAL_LINES && gameModeInsensitive != GAME_MODE_VERTICAL_LINES && gameModeInsensitive != GAME_MODE_DIAGONAL_LINES)
            {
                Console.WriteLine("Invalid input. Please try again");
            }
        }
    }
}
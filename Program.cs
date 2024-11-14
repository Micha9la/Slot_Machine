using System.Runtime.ExceptionServices;
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
                Console.WriteLine("You won " + wager + " Euro");
            }


            int numOfWins = 0;
            if (gameModeInsensitive == GAME_MODE_HORIZONTAL_LINES)
            {
                for (int row = 0; row < rows; row++)
                {
                    bool win = true;
                    int firstElementOfEachRow = grid[row, 0];
                    for (int col = 0; col < columns; col++)
                    {
                        if (grid[row, col] != firstElementOfEachRow)
                        {
                            win = false;
                            break;// Move to the next row after finding a win
                        }
                    }
                    if (win)
                    {
                        numOfWins++;
                    }
                }
                if (numOfWins > 0)
                {
                    Console.WriteLine("You won " + (wager / GRID_SIZE_ROW) * numOfWins + " Euro");
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No row is the same");
                }                
            }

            if (gameModeInsensitive == GAME_MODE_VERTICAL_LINES)
            {
                for (int col = 0; col < columns; col++) 
                {
                    bool win = true;
                    int firstElementOfEachColumn = grid[0, col];
                    for (int row = 0; row < rows; row++)
                    {
                        if (grid[row, col] != firstElementOfEachColumn)
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
                    Console.WriteLine("You won " + (wager / GRID_SIZE_COLUMN) * numOfWins + " Euro");
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No column is the same");
                }
            }


        }
    }
}
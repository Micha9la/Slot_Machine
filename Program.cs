using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int UPPER_NUMBER_RANGE = 3;
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
            Console.WriteLine("How much money would you like to put into your gaming wallet? Please put in only numbers and press ENTER.");
            //read the input as a string, because user input from the console is typically received as a string.
            //Then, TryParse to validate and convert that string to a number.
            //To handle cases where the user might enter non-numeric characters,
            string wallet = Console.ReadLine();
            int walletValidated;
            bool walletValidInput = int.TryParse(wallet, out walletValidated);

            if (walletValidInput) { Console.WriteLine("Your wallet contains " + wallet + "Euro."); }
            else { Console.WriteLine("Invalid input. Please enter a valid number."); }

            Console.WriteLine("How much would you like to wage? Please enter only a number and then ENTER");
            string wager = Console.ReadLine();
            int wagerValidated;
            bool wagerValidInput = int.TryParse(wager, out wagerValidated);

            if (wagerValidInput) { Console.WriteLine("Your wager is " + wager + "Euro."); }
            else { Console.WriteLine("Invalid input. Please enter a valid number."); }

            Console.WriteLine("Please choose ONLY ONE of the following game mode options and ENTER " +
                "and write only the coresponding symbol in capital letters: "
                + GAME_MODE_CENTRAL_LINE + ", for central line. "
                + GAME_MODE_HORIZONTAL_LINES + ", for all horizontal lines. "
                + GAME_MODE_VERTICAL_LINES + ", for all vertical lines. "
                + GAME_MODE_DIAGONAL_LINES + ", for both diagonal lines. ");
            string gameMode = Console.ReadLine();
            string gameModeInsensitive = gameMode.ToUpper();

            while (gameModeInsensitive != GAME_MODE_CENTRAL_LINE && gameModeInsensitive != GAME_MODE_HORIZONTAL_LINES && gameModeInsensitive != GAME_MODE_VERTICAL_LINES && gameModeInsensitive != GAME_MODE_DIAGONAL_LINES)
            {
                Console.WriteLine("Please choose ONLY ONE of the following game mode options and ENTER " +
                "and write only the coresponding symbol in capital letters: "
                + GAME_MODE_CENTRAL_LINE + ", for central line. "
                + GAME_MODE_HORIZONTAL_LINES + ", for all horizontal lines. "
                + GAME_MODE_VERTICAL_LINES + ", for all vertical lines. "
                + GAME_MODE_DIAGONAL_LINES + ", for both diagonal lines. ");
                gameMode = Console.ReadLine();
                gameModeInsensitive = gameMode.ToUpper();

            }
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
                        walletValidated -= wagerValidated;
                        return;
                    }
                }
                Console.WriteLine("You won " + wager + " Euro");
                walletValidated += wagerValidated;
                Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
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
                    Console.WriteLine("You won " + (wagerValidated / GRID_SIZE_ROW) * numOfWins + " Euro, because " + numOfWins + " lineIndex(s) is/are the same");
                    int moneyWon = wagerValidated / GRID_SIZE_ROW * numOfWins;
                    walletValidated += moneyWon;
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No row is the same");
                    walletValidated -= wagerValidated;
                }
                Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
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
                    Console.WriteLine("You won " + (wagerValidated / GRID_SIZE_COLUMN) * numOfWins + " Euro, because " + numOfWins + " column(s) is/are the same.");
                    int moneyWon = wagerValidated / GRID_SIZE_ROW * numOfWins;
                    walletValidated += moneyWon;
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. No column is the same");
                    walletValidated -= wagerValidated;
                }
                Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
            }

            int firstElementLeftToRight = grid[0, 0];
            int firstElementRightToLeft = grid[0, GRID_SIZE_COLUMN - 1];
            if (gameModeInsensitive == GAME_MODE_DIAGONAL_LINES)
            {
                bool win = true;
                for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                {
                    if (grid[lineIndex, GRID_SIZE_COLUMN - 1 - lineIndex] != firstElementRightToLeft)
                    {
                        win = false;
                        break;// Move to the next column after finding a win
                    }
                }
                if (win)
                {
                    numOfWins++;
                }
                int moneyWon = 0;
                if (numOfWins > 0)
                {
                    Console.WriteLine("You won. You have a diagonal win from right to left.");
                    moneyWon = wagerValidated / GRID_SIZE_ROW * numOfWins;
                    walletValidated += moneyWon;
                }
                if (numOfWins == 0)
                {
                    Console.WriteLine("You lost. There is no win from right to left.");
                    walletValidated -= moneyWon;
                }

                int numOfWinsDiagonalLeftToRight = 0;
                bool winLeftToRight = true;
                for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                {
                    Console.WriteLine($"Comparing grid[{lineIndex}, {lineIndex}] = {grid[lineIndex, lineIndex]} with firstElementLeftToRight = {firstElementLeftToRight}");
                    if (grid[lineIndex, lineIndex] != firstElementLeftToRight)
                    {
                        winLeftToRight = false;
                        break;
                    }

                    if (grid[lineIndex, lineIndex] != firstElementLeftToRight)
                    {
                        winLeftToRight = false;
                        break;// Move to the next column after finding a win

                    }
                }
                if (winLeftToRight)
                {
                    numOfWinsDiagonalLeftToRight++;
                }
                if (numOfWinsDiagonalLeftToRight > 0)
                {
                    Console.WriteLine("You won. You have a diagonal win from left to right.");
                    moneyWon = wagerValidated / GRID_SIZE_ROW * numOfWins;
                    walletValidated += moneyWon;
                }
                if (numOfWinsDiagonalLeftToRight == 0)
                {
                    Console.WriteLine("You lost. There is no win from left to right.");
                    walletValidated -= moneyWon;
                }
                Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
            }

        }


    }
}

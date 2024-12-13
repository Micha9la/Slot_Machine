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
            Console.WriteLine("How much money would you like to put into your gaming wallet? Please put in only numbers and press ENTER.");           
            string wallet = Console.ReadLine();
            double walletValidated;
            bool walletValidInput = double.TryParse(wallet, out walletValidated);
            
            while (walletValidated > 0)
            {   
                while (!walletValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    string walletProper = Console.ReadLine();
                    walletValidInput = double.TryParse(walletProper, out walletValidated);
                }
                
                string wager = Console.ReadLine();
                double wagerValidated;
                bool wagerValidInput = double.TryParse(wager, out wagerValidated);

                while (!wagerValidInput) 
                { 
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    string wagerProper = Console.ReadLine();
                    wagerValidInput = double.TryParse(wagerProper, out wagerValidated);
                }
                while (wagerValidated > walletValidated)
                {
                    Console.WriteLine("The wager you have chosen is too high.");
                    Console.WriteLine("Enter a wager lower or equal to " + walletValidated + " Euro.");
                    string newWager = Console.ReadLine();
                    wagerValidInput = double.TryParse(newWager, out wagerValidated);
                    if (wagerValidated <= walletValidated)
                        break;
                }

                Console.WriteLine("Your wager is " + wagerValidated + " Euro.");

                Console.WriteLine("Please choose ONLY ONE of the following game mode options and press ENTER: "
                    + GAME_MODE_CENTRAL_LINE + ", for central line. "
                    + GAME_MODE_HORIZONTAL_LINES + ", for all horizontal lines. "
                    + GAME_MODE_VERTICAL_LINES + ", for all vertical lines. "
                    + GAME_MODE_DIAGONAL_LINES + ", for both diagonal lines. ");
                string gameModeInsensitive = Console.ReadLine().ToUpper();

                List<string> gameModes = new List<string>();
                gameModes.Add("A");
                gameModes.Add("B");
                gameModes.Add("C");
                gameModes.Add("D");

                while (!gameModes.Contains(gameModeInsensitive))
                {
                    Console.WriteLine("Please choose ONLY ONE of the following game mode options and ENTER " +
                    "and write only the coresponding symbol in capital letters: "
                    + GAME_MODE_CENTRAL_LINE + ", for central line. "
                    + GAME_MODE_HORIZONTAL_LINES + ", for all horizontal lines. "
                    + GAME_MODE_VERTICAL_LINES + ", for all vertical lines. "
                    + GAME_MODE_DIAGONAL_LINES + ", for both diagonal lines. ");
                    gameModeInsensitive = Console.ReadLine().ToUpper();                    

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
                int columnLength = grid.GetLength(1);

                int middleRowIndex = rowLength / GRID_DIVISOR;
                int firstElementMiddleRow = grid[middleRowIndex, 0];
                if (gameModeInsensitive == GAME_MODE_CENTRAL_LINE)
                {
                    bool win = true;
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        if (grid[middleRowIndex, columnIndex] != firstElementMiddleRow)
                        {
                            win = false;
                            Console.WriteLine("You lost " + wager + " Euro");
                            walletValidated -= wagerValidated;
                            Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
                            break;
                        }
                    }
                    if (win)
                    {
                        Console.WriteLine("You won " + wager + " Euro");
                        walletValidated += wagerValidated;
                        Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
                    }
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
                                break;// Move to the next lineIndex after finding a winDiagonal
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
                        double moneyWon = wagerValidated / GRID_SIZE_ROW * numOfWins;
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
                                break;// Move to the next column after finding a winDiagonal
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
                        double moneyWon = wagerValidated / GRID_SIZE_ROW * numOfWins;
                        walletValidated += moneyWon;
                    }
                    if (numOfWins == 0)
                    {
                        Console.WriteLine("You lost. No column is the same");
                        walletValidated -= wagerValidated;
                    }
                    Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
                }

                int numOfWinsDiagonal = 0;
                int firstElementLeftToRight = grid[0, 0];
                int firstElementRightToLeft = grid[0, GRID_SIZE_COLUMN - 1];
                if (gameModeInsensitive == GAME_MODE_DIAGONAL_LINES)
                {
                    bool winDiagonal = true;
                    for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                    {
                        if (grid[lineIndex, GRID_SIZE_COLUMN - 1 - lineIndex] != firstElementRightToLeft)
                        {
                            winDiagonal = false;
                            break;// Move to the next column after finding a winDiagonal
                        }
                    }
                    if (winDiagonal)
                    {
                        numOfWinsDiagonal++;
                    }

                    for (int lineIndex = 0; lineIndex < rowLength; lineIndex++)
                    {
                        if (grid[lineIndex, lineIndex] != firstElementLeftToRight)
                        {
                            winDiagonal = false;
                            break;
                        }

                        if (grid[lineIndex, lineIndex] != firstElementLeftToRight)
                        {
                            winDiagonal = false;
                            break;// Move to the next column after finding a winDiagonal

                        }
                    }
                    if (winDiagonal)
                    {
                        numOfWinsDiagonal++;
                    }

                    if (numOfWinsDiagonal == 2)
                    {
                        Console.WriteLine("You have two diagonal wins. You won: " + wagerValidated);
                        walletValidated += wagerValidated;
                    }

                    if (numOfWinsDiagonal == 0)
                    {
                        Console.WriteLine("There is only one or no diagonal win. You lost: " + wagerValidated);
                        walletValidated -= wagerValidated;
                    }
                    Console.WriteLine("Your wallet has now " + walletValidated + " Euro in it.");
                }
                Console.WriteLine("Write X now, if you like to stop the game");
                string endGame = Console.ReadLine().ToLower();
                if (endGame == "x")
                {
                    break;
                }
            }
        }

    }
}


using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            UIMethods.WelcomeMessage();           
            double walletValidated = UIMethods.GetValidWalletAmount();//returned value (wallet amount) can be stored in walletValidated and used later in the program

            // Start game loop
            while (true)  // Infinite loop, exits when the user inputs 'X'
            {
                //get wager amount
                double wagerValidated = UIMethods.GetValidWagerAmount(walletValidated);
                Console.WriteLine($"Your wager is {wagerValidated} Euro.");

                // Game Mode Selection
                string gameMode = UIMethods.GetValidGameMode();

                // Generate Grid
                UIMethods.DisplayGeneratedGrid();

                //In a 2D array, the first dimension (0) represents rows, and the second dimension (1) represents columns
                int rowLength = grid.GetLength(0);//stores the number of rows in the grid
                int columnLength = grid.GetLength(1);//stores the number of columns.

                bool win = false;
                // Central Line Check
                if (gameMode == Constants.GAME_MODE_CENTRAL_LINE)
                {
                    int middleRowIndex = rowLength / Constants.GRID_DIVISOR;
                    int firstElementMiddleRow = grid[middleRowIndex, 0];                    
                    win = true;
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        if (grid[middleRowIndex, columnIndex] != firstElementMiddleRow)
                        {
                            win = false;                           
                            break;
                        }
                    }
                }
                // ---Horizontal Lines Check ---
                if (gameMode == Constants.GAME_MODE_HORIZONTAL_LINES)
                {
                    win = true;
                    for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
                    {
                        int firstElement = grid[rowIndex, 0];
                        for (int columnIndex = 1; columnIndex < columnLength; columnIndex++)
                        {
                            if (grid[rowIndex, columnIndex] != firstElement)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (!win) break;
                    }
                }

                // --- Vertical Lines Check ---
                if (gameMode == Constants.GAME_MODE_VERTICAL_LINES)
                {
                    win = true;
                    for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                    {
                        int firstElement = grid[0, columnIndex];
                        for (int rowIndex = 1; rowIndex < rowLength; rowIndex++)
                        {
                            if (grid[rowIndex, columnIndex] != firstElement)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (!win) break;
                    }
                }

                // --- Diagonal Lines Check ---
                if (gameMode == Constants.GAME_MODE_DIAGONAL_LINES)
                {
                    bool mainDiagonal = (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]);
                    bool antiDiagonal = (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]);

                    win = mainDiagonal && antiDiagonal;
                }

                // --- Wallet Update ---
                if (win)
                {
                    Console.WriteLine($"You won {wagerValidated} Euro!");
                    walletValidated += wagerValidated;
                }
                else
                {
                    Console.WriteLine($"You lost {wagerValidated} Euro.");
                    walletValidated -= wagerValidated;
                }

                Console.WriteLine($"Your wallet now has {walletValidated} Euro.");

                if (walletValidated <= 0)
                {
                    Console.WriteLine("You have no money left. Game over!");
                    break;
                }
                // End Game Check
                Console.WriteLine("Write 'X' now if you want to stop the game, or press ENTER to continue.");
                string endGame = Console.ReadLine().ToLower();
                if (endGame == "x")
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
            }


        }

    }

}



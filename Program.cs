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

                // Generate and store grid
                int[,] grid = UIMethods.DisplayGeneratedGrid();

                bool win = false;
                // Central Line Check
                if (gameMode == Constants.GAME_MODE_CENTRAL_LINE)
                {
                    win = UIMethods.CheckCentralLineWin(grid);
                }
                // ---Horizontal Lines Check ---
                if (gameMode == Constants.GAME_MODE_HORIZONTAL_LINES)
                {
                    win = UIMethods.CheckHorizontalLinesWin(grid);
                }

                // --- Vertical Lines Check ---
                if (gameMode == Constants.GAME_MODE_VERTICAL_LINES)
                {
                    win = UIMethods.CheckVerticalLinesWin(grid);
                }

                // --- Diagonal Lines Check ---
                if (gameMode == Constants.GAME_MODE_DIAGONAL_LINES)
                {
                    win = UIMethods.CheckDiagonalLinesWin(grid);
                }

                // --- Wallet Update ---
                walletValidated = UIMethods.UpdateWallet(walletValidated, wagerValidated, grid);

              
                // End Game Check
                if (UIMethods.CheckEndGame())
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
            }


        }

    }

}



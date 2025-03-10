using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public class UIMethods
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the slot machine.");
        }
        public static double GetValidWalletAmount()
        {
            double walletValidated = 0;//use double for the wallet amount because money usually isn't always a whole number
            bool walletValidInput = false;

            // Loop until user enters a valid positive wallet amount
            while (!walletValidInput || walletValidated <= 0)// loop will continue running until walletValidInput becomes true and walletValidated is greater than 0.
            {
                Console.WriteLine("How much money would you like to put into your gaming wallet? Please enter only numbers and press ENTER.");
                string walletInput = Console.ReadLine();
                walletValidInput = double.TryParse(walletInput, out walletValidated);

                if (!walletValidInput || walletValidated <= 0)//!walletValidInput is true when walletValidInput is false.
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive number.");
                }
            }
            return walletValidated;  // Return valid wallet amount
        }
        public static double GetValidWagerAmount(double walletValidated)
        {
            // --- Get the wager amount ---
            double wagerValidated = 0;
            bool wagerValidInput = false;

            while (!wagerValidInput || wagerValidated > walletValidated || wagerValidated <= 0)
            {
                Console.WriteLine($"Enter your wager (must be ≤ {walletValidated} Euro):");
                string wagerInput = Console.ReadLine();
                wagerValidInput = double.TryParse(wagerInput, out wagerValidated);

                if (!wagerValidInput || wagerValidated > walletValidated || wagerValidated <= 0)
                {
                    Console.WriteLine("Invalid wager. Please enter a number within your wallet balance and greater than zero.");
                }
            }
            return wagerValidated; //Return valid wager amount
        }

        public static string GetValidGameMode()
        {
            List<string> gameModes = new List<string>
            {
                Constants.GAME_MODE_CENTRAL_LINE,
                Constants.GAME_MODE_HORIZONTAL_LINES,
                Constants.GAME_MODE_VERTICAL_LINES,
                Constants.GAME_MODE_DIAGONAL_LINES
            };
            // Game Mode Selection
            Console.WriteLine("Please choose ONLY ONE of the following game mode options and press ENTER: "
                    + Constants.GAME_MODE_CENTRAL_LINE + " (central line), "
                    + Constants.GAME_MODE_HORIZONTAL_LINES + " (horizontal lines), "
                    + Constants.GAME_MODE_VERTICAL_LINES + " (vertical lines), "
                    + Constants.GAME_MODE_DIAGONAL_LINES + " (diagonal lines).");

            string gameModeInsensitive = Console.ReadLine().ToUpper();            

            while (!gameModes.Contains(gameModeInsensitive))//while loop will continue as long as gameModeInsensitive is not in the list
            {
                Console.WriteLine("Invalid input! Please choose one of: "
                    + Constants.GAME_MODE_CENTRAL_LINE + " (central line), "
                    + Constants.GAME_MODE_HORIZONTAL_LINES + " (horizontal lines), "
                    + Constants.GAME_MODE_VERTICAL_LINES + " (vertical lines), "
                    + Constants.GAME_MODE_DIAGONAL_LINES + " (diagonal lines).");

                gameModeInsensitive = Console.ReadLine().ToUpper();
            }
            return gameModeInsensitive;
        }

        public static void DisplayGeneratedGrid()
        {
            Random random = new Random();
            int[,] grid = new int[Constants.GRID_SIZE_ROW, Constants.GRID_SIZE_COLUMN];

            for (int lineIndex = 0; lineIndex < Constants.GRID_SIZE_ROW; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < Constants.GRID_SIZE_COLUMN; columnIndex++)
                {
                    grid[lineIndex, columnIndex] = random.Next(Constants.LOWER_NUMBER_RANGE, Constants.UPPER_NUMBER_RANGE);
                    Console.Write(grid[lineIndex, columnIndex] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Above you see the grid.");
        }
        public static string GiveUserFeedback(string messageToUser)
        {
            Console.WriteLine(messageToUser);
            return Console.ReadLine();
        }
    }
}

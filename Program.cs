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
            Random random = new Random();
            Console.WriteLine("Welcome to the slot machine.");
            Console.WriteLine("How much would you like to wage? Please enter only a number");
            int wager = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please choose ONLY ONE of the following game mode options " +
                "and write only the coresponding symbol in capital letters: " +
                "A for central line, B for all horizontal lines, C for all vertikal lines, D for all diagonal lines");
            string gameMode = Console.ReadLine();
            Console.WriteLine("You have picked your prefered option and you wager. Below you see the result...");

            int[,] grid = new int[3, 3];

            for (int lineIndex = 0; lineIndex < 3; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    int randomNumber = random.Next(LOWER_NUMBER_RANGE, UPPER_NUMBER_RANGE);
                    grid[lineIndex, columnIndex] = randomNumber;
                    Console.Write(grid[lineIndex, columnIndex] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("end of loop");
            
            if (gameMode == "A")
            {
                ;
                ;
                ;
            }
            if (gameMode == "B")
            {
                ;
                ;
                ;
            }
            if (gameMode == "C")
            {
                ;
                ;
                ;
            }
            if (gameMode == "D")
            {
                ;
                ;
                ;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
            }
        }
    }
}
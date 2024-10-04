namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int UPPER_NUMBER_RANGE = 101;
            const int LOWER_NUMBER_RANGE = 1;
            Random random = new Random();
            int randomNumber = random.Next(LOWER_NUMBER_RANGE, UPPER_NUMBER_RANGE);


            Console.WriteLine("Welcome to the slot machine.");
            int[,] grid = new int[3, 3];

            for (int lineIndex = randomNumber; lineIndex < 3; lineIndex++)
            {
                for (int columnIndex = randomNumber; columnIndex < 3; columnIndex++)
                {
                    Console.Write(grid[lineIndex, columnIndex] + " ");
                }
                //this prompt helps to move curser to next line in the console.
                //After printing all the values in one row of the grid array,
                //Console.WriteLine() is called, which moves the cursor to the next line.
                Console.WriteLine();
            }

        }
    }
}
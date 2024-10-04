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
            Console.WriteLine("Welcome to the slot machine.");


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
        }
    }
}
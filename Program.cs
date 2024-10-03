namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the slot machine.");
            int[,] grid = new int[3, 3];
            for (int lineIndex = 0; lineIndex < 3; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                { 
                    Console.Write(grid[lineIndex, columnIndex] ); 
                }
            }

        }
    }
}
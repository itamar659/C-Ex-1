using System;

namespace B21_Ex01_3
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the size of the hourglass:");
            string hourglassSizeStr = Console.ReadLine();

            if (int.TryParse(hourglassSizeStr, out int hourglassSize))
            {
                string myHourglass = B21_Ex01_2.Program.GetHourGlass(hourglassSize);
                Console.WriteLine(myHourglass);
            }
            else
            {
                Console.WriteLine("You required to enter a natural number.");
            }
        }
    }
}

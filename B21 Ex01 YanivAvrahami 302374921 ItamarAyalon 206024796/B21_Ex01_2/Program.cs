using System;
using System.Text;

namespace B21_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(GetHourGlass(5));
        }

        public static string GetHourGlass(int i_Size)
        {
            StringBuilder outputStrBuilder = new StringBuilder();

            if (i_Size <= 0)
            {
                // return an error to the user
                outputStrBuilder.Append("Size has to be positive number.");
            }
            else
            {
                i_Size = i_Size % 2 == 0 ? i_Size + 1 : i_Size;
                outputStrBuilder.Append(getHourGlassRec((uint)i_Size));
            }

            return outputStrBuilder.ToString();
        }

        private static string getHourGlassRec(uint i_Size, uint i_StartFrom = 0)
        {
            StringBuilder hourGlassStr = new StringBuilder();
            string lineOfSizeStars = createNStars(i_Size, i_StartFrom);

            if (i_Size > 2)
            {
                string smallHourGlass = getHourGlassRec(i_Size - 2, i_StartFrom + 1);

                hourGlassStr.AppendLine(lineOfSizeStars);
                hourGlassStr.Append(smallHourGlass);
            }

            hourGlassStr.AppendLine(lineOfSizeStars);

            return hourGlassStr.ToString();
        }

        private static string createNStars(uint i_NumOfStars, uint i_StartFrom)
        {
            StringBuilder starsStr = new StringBuilder();

            // Add indentations
            for (int i = 0; i < i_StartFrom; i++)
            {
                starsStr.Append(' ');
            }

            // Add stars
            for (int i = 0; i < i_NumOfStars; i++)
            {
                starsStr.Append('*');
            }

            return starsStr.ToString();
        }
    }
}

using System;

namespace B21_Ex01_6
{
     class Program
     {
          public static void Main()
          {
               Console.WriteLine("Enter a natural number with 6 digits:");
               
               string numberStr = Console.ReadLine();
               int number;

               bool goodLength = numberStr.Length == 6;
               bool successfullyParsed = int.TryParse(numberStr, out number);

               if (goodLength && successfullyParsed)
               {
                    printStatisticsOnNumber(number);
               }
               else
               {
                    Console.WriteLine("Error: Invalid Input");
               }
          }

          private static void printStatisticsOnNumber(int i_Number)
          {
               string numString = i_Number.ToString();
               
               string msg = String.Format(
@"Biggest Digit in {0} is: {1}
Smallest Digit in {2} is: {3} 
Number of digits that divide by {4} is: {5} 
Number of digits that are bigger than {6} is: {7}",
               i_Number, getBiggestDigit(i_Number),
               i_Number, getSmallestDigit(i_Number),
               3, getNumOfDigitsThatDivideByN(i_Number, 3),
               char.Parse(numString.Substring(numString.Length - 1)) - '0', getNumOfDigitsBiggerThanDigit(numString.Length - 1, i_Number));

               Console.WriteLine(msg);
          }
          
          private static int getNumOfDigitsBiggerThanDigit(int i_DigitIndex, int i_Number) 
          {
               int validDigits = 0;

               string numberString = i_Number.ToString();

               for (int i = 0; i < numberString.Length; i++)
               {
                    if (i == i_DigitIndex)
                    {
                         continue;
                    }

                    if (numberString[i] > numberString[i_DigitIndex])
                    {
                         validDigits++;
                    }
               }

               return validDigits;
          }

          private static bool isDigitDivideByN(int i_Digit, int i_N)
          {
               bool isDivide = i_Digit % i_N == 0;
               
               return isDivide;
          }

          private static int getNumOfDigitsThatDivideByN(int i_Number, int i_N)
          {
               int validDigits = 0;

               string numberString = i_Number.ToString();

               for(int i = 0; i < numberString.Length; i++)
               {
                    if(isDigitDivideByN(numberString[i], i_N))
                    {
                         validDigits++;
                    }
               }

               return validDigits;
          }

          private static int getSmallestDigit(int i_Number)
          {
               string numberString = i_Number.ToString();

               if(numberString.Length == 1)
               {
                    return i_Number;
               }

               int smallestDigit = numberString[0] - '0';
               
               for (int i = 1; i < numberString.Length; i++)
               {
                    if (numberString[i] - '0' < smallestDigit)
                    {
                         smallestDigit = numberString[i] - '0';
                    }
               }

               return smallestDigit;
          }

          private static int getBiggestDigit(int i_Number)
          {
               string numberString = i_Number.ToString();

               if (numberString.Length == 1)
               {
                    return i_Number;
               }

               int biggestDigit = numberString[0] - '0';

               for (int i = 1; i < numberString.Length; i++)
               {
                    if (numberString[i] - '0' > biggestDigit)
                    {
                         biggestDigit = numberString[i] - '0';
                    }
               }

               return biggestDigit;
          }

          private static bool isStringContainsOnlyDigits(string str)
          {
               bool hasOnlyDigits = false;
               
               hasOnlyDigits = int.TryParse(str, out int temp);

               return hasOnlyDigits;
          }
     }
}
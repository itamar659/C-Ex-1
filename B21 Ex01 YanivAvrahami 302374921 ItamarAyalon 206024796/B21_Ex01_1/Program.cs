using System;
using System.Text;

namespace B21_Ex01_1
{
     class Program
     {
          public static void Main()
          {
               const int k_NumOfRequests = 3;

               Console.WriteLine("Please enter a binary number with 7 digits:");
               string[] binaryArr = getNBinaryNumbersFromUser(k_NumOfRequests);

               Console.Write("The numbers you entered in decimal: ");
               printBinaryAsDecimalNumbers(binaryArr);

               printStatisticsOnBinaryNumbers(binaryArr);

               Console.WriteLine();

               printExamples();
          }

          private static void printBinaryAsDecimalNumbers(string[] i_BinaryNumbers)
          {
               int[] decimalArr = parseToDecimalArr(i_BinaryNumbers);
               printDecimalNumbers(decimalArr);
          }

          private static void printExamples()
          {
               string[] binaryArr = new string[]{ "1111011", "1101110", "1000000" };
               Console.WriteLine("Example 1:");
               printExample(binaryArr);

               Console.WriteLine();

               binaryArr = new string[]{ "0010111", "0110000", "0011100" };
               Console.WriteLine("Example 2:");
               printExample(binaryArr);

               Console.WriteLine();

               binaryArr = new string[]{ "1011111", "1101111", "0110011" };
               Console.WriteLine("Example 3:");
               printExample(binaryArr);
          }

          private static void printExample(string[] i_BinaryNumbers)
          {
               Console.Write("The binary numbers in decimal: ");
               printBinaryAsDecimalNumbers(i_BinaryNumbers);

               printStatisticsOnBinaryNumbers(i_BinaryNumbers);
          }

          private static string[] getNBinaryNumbersFromUser(int i_NumOfNumbersToRequest)
          {
               string[] binaryNumberArr = new string[i_NumOfNumbersToRequest];

               for (int i = 0; i < i_NumOfNumbersToRequest; i++)
               {
                    binaryNumberArr[i] = getBinaryNumberFromUser();
               }

               return binaryNumberArr;
          }
          
          
          private static string getBinaryNumberFromUser()
          {
               bool isValidBinaryNumber = false;
               string binaryNumber = "";

               while(!isValidBinaryNumber)
               {
                    string userInput = Console.ReadLine();
                    isValidBinaryNumber = isValidBinaryNumberInput(userInput);
                    if (isValidBinaryNumberInput(userInput))
                    {
                         binaryNumber = userInput;
                         isValidBinaryNumber = true;
                    }
                    else
                    {
                         Console.WriteLine("Something went wrong. Please try again.");
                    }
               }
               
               return binaryNumber;
          }
          
          private static bool isValidBinaryNumberInput(string i_BinaryNumberStr)
          {
               const uint k_NumOfDigits = 7;
               bool isValidInput = (i_BinaryNumberStr.Length == k_NumOfDigits) && IsBinaryNumber(i_BinaryNumberStr);
               return isValidInput;
          }

          private static bool IsBinaryNumber(string i_Str)
          {
               return isOnlyOnesAndZeros(i_Str) && i_Str.Length == 7;
          }
          
          private static bool isOnlyOnesAndZeros(string i_Str)
          {
               bool res = true;

               foreach (char ch in i_Str)
               {
                    if (ch == '0' || ch == '1')
                    {
                         continue;
                    }

                    res = false;
                    break;
               }

               return res;
          }

          private static void printDecimalNumbers(int[] i_DecimalNumberArr)
          {
               StringBuilder msg = new StringBuilder();

               foreach(int decimalNumber in i_DecimalNumberArr)
               {
                    msg.Append(decimalNumber);
                    msg.Append(' ');
               }

               Console.WriteLine(msg);
          }

          private static int[] parseToDecimalArr(string[] i_BinaryNumberArr)
          {
               int[] decimalArr = new int[i_BinaryNumberArr.Length];

               for(int i = 0; i < i_BinaryNumberArr.Length; i++)
               {
                    decimalArr[i] = convertBinaryToDecimal(i_BinaryNumberArr[i]);
               }

               return decimalArr;
          }

          private static int convertBinaryToDecimal(string i_S)
          {
               int sum = 0;
               for (int i = 0; i < i_S.Length; i++)
               {
                    sum += getDigitFromBinary(i_S, i_S.Length - i - 1) * (int)Math.Pow(2, i);
               }

               return sum;
          }

          private static int getDigitFromBinary(string i_S, int i_I)
          {
               int binaryDigit = i_S[i_I] - '0';

               return binaryDigit;
          }

          private static void printStatisticsOnBinaryNumbers(string[] i_BinaryNumberArr)
          {
               float avgOfZeros = getAvgOfZerosInBinaryNumbers(i_BinaryNumberArr);
               float avgOfOnes = getAvgOfOnesInBinaryNumbers(i_BinaryNumberArr);
               int numOfPower2Numbers = getNumberOfPower2Numbers(i_BinaryNumberArr);
               int numOfNumbersPresentedInDescendingOrder = getNumberOfBinaryNumberPresentedInDecendingOrder(i_BinaryNumberArr);
               string maxBinaryNumber = getMax(i_BinaryNumberArr);
               string minBinaryNumber = getMin(i_BinaryNumberArr);

               string msg = string.Format(
@"The average zeros: {0}
The average ones: {1}
Number of numbers that are power of 2: {2}
Number of numbers that their digits represent descending order: {3}
Max is: {4}, Min is: {5}",
                    avgOfZeros,
                    avgOfOnes,
                    numOfPower2Numbers,
                    numOfNumbersPresentedInDescendingOrder,
                    maxBinaryNumber,
                    minBinaryNumber);

               Console.WriteLine(msg);
          }
          
          public enum eBinaryDigit
          {
               One,
               Zero
          }

          private static int getNumberOfPower2Numbers(string[] i_BinaryNumberArray)
          {
               int totalPowerOf2Numbers = 0;

               for (int i = 0; i < i_BinaryNumberArray.Length; i++)
               {
                    if (isPowerOfTwo(i_BinaryNumberArray[i]))
                    {
                         totalPowerOf2Numbers++;
                    }
               }

               return totalPowerOf2Numbers;
          }
          
          private static bool isPowerOfTwo(string i_BinaryNumber)
          {
               bool seenOneSetDigit = false;
               bool isPowerOfTwo = false;

               for (int i = 0; i < i_BinaryNumber.Length; i++)
               {
                    if (i_BinaryNumber[i] == '1')
                    {
                         if (seenOneSetDigit)
                         {
                              isPowerOfTwo = false;
                              break;
                         }
                         else
                         {
                              isPowerOfTwo = true;
                              seenOneSetDigit = true;
                         }
                    }
               }

               return isPowerOfTwo;
          }

          private static string getMax(string[] i_BinaryNumberArray)
          {
               string currentMax = i_BinaryNumberArray[0];

               for (int i = 1; i < i_BinaryNumberArray.Length; i++)
               {
                    if (convertBinaryToDecimal(currentMax) < convertBinaryToDecimal(i_BinaryNumberArray[i]))
                    {
                         currentMax = i_BinaryNumberArray[i];
                    }
               }

               return currentMax;
          }

          private static string getMin(string[] i_BinaryNumberArray)
          {
               string currentMin = i_BinaryNumberArray[0];

               for (int i = 1; i < i_BinaryNumberArray.Length; i++)
               {
                    if (convertBinaryToDecimal(currentMin) > convertBinaryToDecimal(i_BinaryNumberArray[i]))
                    {
                         currentMin = i_BinaryNumberArray[i];
                    }
               }

               return currentMin;
          }

          private static float getAvgOfZerosInBinaryNumbers(string[] i_BinaryNumberArray)
          {
               return getAvgOfOnesZerosInBinaryNumbers(i_BinaryNumberArray, eBinaryDigit.Zero);
          }

          private static float getAvgOfOnesInBinaryNumbers(string[] i_BinaryNumberArray)
          {
               return getAvgOfOnesZerosInBinaryNumbers(i_BinaryNumberArray, eBinaryDigit.One);
          }

          private static float getAvgOfOnesZerosInBinaryNumbers(string[] i_BinaryNumberArray, eBinaryDigit i_BinaryDigit)
          {
               int totalZeros = 0;
               float avgOfZeros = 0;

               for (int i = 0; i < i_BinaryNumberArray.Length; i++)
               {
                    totalZeros += getNumberOfBinaryDigitOccurrences(i_BinaryNumberArray[i], i_BinaryDigit);
               }

               if (i_BinaryNumberArray.Length != 0)
               {
                    avgOfZeros = (float)totalZeros / i_BinaryNumberArray.Length;
               }

               return avgOfZeros;
          }

          private static int getNumberOfBinaryNumberPresentedInDecendingOrder(string[] i_BinaryNumberArray)
          {
               int numOfDescendingOrderNumbers = 0;

               foreach (string currentBinaryNumber in i_BinaryNumberArray)
               {
                    if(isNumberDigitsInDescendingOrder(convertBinaryToDecimal(currentBinaryNumber)))
                    {
                         numOfDescendingOrderNumbers++;
                    }
               }

               return numOfDescendingOrderNumbers;
          }

          private static int getNumberOfBinaryDigitOccurrences(string i_BinaryNumber, eBinaryDigit i_BinaryDigit)
          {
               int occurrences = 0;
               char binaryDigitAsChar = '0';

               if (i_BinaryDigit == eBinaryDigit.One)
               {
                    binaryDigitAsChar = '1';
               }

               if (i_BinaryDigit == eBinaryDigit.Zero)
               {
                    binaryDigitAsChar = '0';
               }

               occurrences = getNumOfCharOccurrences(i_BinaryNumber, binaryDigitAsChar);

               return occurrences;
          }

          private static int getNumOfCharOccurrences(string i_BinaryNumber, char i_Char)
          {
               int numOfOccurrences = 0;

               for (int i = 0; i < i_BinaryNumber.Length; i++)
               {
                    if (i_BinaryNumber[i] == i_Char)
                    {
                         numOfOccurrences++;
                    }
               }

               return numOfOccurrences;
          }

          private static bool isNumberDigitsInDescendingOrder(int i_Number)
          {
               bool isDescendingOrder;

               if (i_Number < 10)
               {
                    isDescendingOrder = true;
               }
               else
               {
                    int lastValue = i_Number % 10;
                    i_Number /= 10;

                    if (i_Number % 10 < lastValue)
                    {
                         isDescendingOrder = isNumberDigitsInDescendingOrder(i_Number);
                    }
                    else
                    {
                         isDescendingOrder = false;
                    }
               }

               return isDescendingOrder;
          }
     }
}
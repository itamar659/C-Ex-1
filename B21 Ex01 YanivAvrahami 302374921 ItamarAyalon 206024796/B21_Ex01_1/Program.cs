using System;

namespace B21_Ex01_1
{
     class Program
     {
          public static void Main()
          {
               const int k_NumOfNumbersToRequest = 3;
               
               string[] strBinaryNumbers = new string[k_NumOfNumbersToRequest];

               // get 3 binary numbers from the user
               Console.WriteLine(@"Please enter {0} numbers in a binary format:", k_NumOfNumbersToRequest);
               for (int i = 0; i < k_NumOfNumbers; i++)
               {
                    strBinaryNumbers[i] = Console.ReadLine();
               }

               // convert the binary numbers to decimal numbers
               
               // print the numbers in decimal form

               // print statistics about the input:
               // sum all the zeros that was enters

          }
          
          private const uint k_NumOfNumbers = 3;
          private const uint k_NumOfDigits = 7;

          public void LaunchUI()
          {
               

              

               Console.Write("The numbers you entered in decimal: ");
               for (int i = 0; i < k_NumOfNumbers; i++)
               {
                    Console.Write(binaryNumbers[i].ToDecimalNumber().ToString()); // TODO: Add ToDecimalNumber method in binaryNumber
               }

               float avgOfZeors = BinaryNumberUtiles.GetAvgOfZerosInBinaryNumbers(binaryNumbers);
               Console.WriteLine(string.Format("The average zeros: {0}", avgOfZeors));

               float avgOfOnes = BinaryNumberUtiles.GetAvgOfOnesInBinaryNumbers(binaryNumbers);
               Console.WriteLine(string.Format("The average ones: {0}", avgOfOnes));

               int numOfPower2Numbers = BinaryNumberUtiles.GetNumberOfPower2Numbers(binaryNumbers);
               Console.WriteLine(string.Format("Number of numbers that are power of 2: {0}", numOfPower2Numbers));

               int numOfNumbersPresentedInDecendingOrder = BinaryNumberUtiles.GetNumberOfBinaryNumberPresentedInDecendingOrder(binaryNumbers);
               Console.WriteLine(string.Format("Number of numbers that their digits represent decending order: {0}", numOfNumbersPresentedInDecendingOrder));

               BinaryNumber maxBinaryNumber = BinaryNumberUtiles.GetMax(binaryNumbers);
               BinaryNumber minBinaryNumber = BinaryNumberUtiles.GetMin(binaryNumbers);
               Console.WriteLine(string.Format("Max is: {0}, Min is: {1}", maxBinaryNumber, minBinaryNumber));


          }

          private BinaryNumber getBinaryNumbersFromUser()
          {
               bool isValidInput;
               string binaryNumberStr;

               Console.WriteLine("Please enter a binary number with 7 digits:");

               do
               {
                    binaryNumberStr = Console.ReadLine();
                    isValidInput = isBNumberValidInput(binaryNumberStr);
                    if (!isValidInput)
                    {
                         Console.WriteLine("Something went wrong. Please try again.");
                    }
               } while (!isValidInput);

               BinaryNumber binaryNumber = new BinaryNumber(binaryNumberStr);

               return binaryNumber;
          }

          private bool isBNumberValidInput(string i_BinaryNumberStr)
          {
               return (i_BinaryNumberStr.Length == k_NumOfDigits) && BinaryNumber.IsBinaryNumber(i_BinaryNumberStr);
          }










          public static bool IsNumberDigitsInDescendingOrder(int i_Number)
          {
               bool isDescendingOrder;

               if(i_Number < 10)
               {
                    isDescendingOrder = true;
               }
               else
               {
                    int lastValue = i_Number % 10;
                    i_Number /= 10;

                    if(i_Number % 10 < lastValue)
                    {
                         isDescendingOrder = IsNumberDigitsInDescendingOrder(i_Number);
                    }
                    else
                    {
                         isDescendingOrder = false;
                    }
               }

               return isDescendingOrder;
          }



          public static float GetAvgOfZerosInBinaryNumbers(BinaryNumber[] i_BinaryNumberArray)
          {
               return getAvgOfOnesZerosInBinaryNumbers(i_BinaryNumberArray, BinaryNumber.eBinaryDigit.Zero);
          }

          public static float GetAvgOfOnesInBinaryNumbers(BinaryNumber[] i_BinaryNumberArray)
          {
               return getAvgOfOnesZerosInBinaryNumbers(i_BinaryNumberArray, BinaryNumber.eBinaryDigit.One);
          }

          private static float getAvgOfOnesZerosInBinaryNumbers(BinaryNumber[] i_BinaryNumberArray, BinaryNumber.eBinaryDigit i_BinaryDigit)
          {
               int totalZeros = 0;
               float avgOfZeros = 0;

               for (int i = 0; i < i_BinaryNumberArray.Length; i++)
               {
                    totalZeros += i_BinaryNumberArray[i].GetNumberOfBinaryDigitOccurrences(i_BinaryDigit);
               }

               if (i_BinaryNumberArray.Length != 0)
               {
                    avgOfZeros = (float)totalZeros / i_BinaryNumberArray.Length;
               }

               return avgOfZeros;
          }

          public static int GetNumberOfPower2Numbers(BinaryNumber[] i_BinaryNumberArray)
          {
               int totalPowerOf2Numbers = 0;

               for (int i = 0; i < i_BinaryNumberArray.Length; i++)
               {
                    if (i_BinaryNumberArray[i].IsPowerOfTwo())
                    {
                         totalPowerOf2Numbers++;
                    }
               }

               return totalPowerOf2Numbers;
          }

          public static int GetNumberOfBinaryNumberPresentedInDecendingOrder(BinaryNumber[] i_BinaryNumberArray)
          {
               int numOfDecendingOrderNumbers = 0;

               foreach (BinaryNumber currentBinaryNumber in i_BinaryNumberArray)
               {
                    if (NumberUtiles.IsNumberDigitsInDescendingOrder(currentBinaryNumber.ToDecimalNumber()) == true)
                    {
                         numOfDecendingOrderNumbers++;
                    }
               }

               return numOfDecendingOrderNumbers;
          }

          public static BinaryNumber GetMax(BinaryNumber[] i_BinaryNumberArray)
          {
               BinaryNumber currentMax = i_BinaryNumberArray[0];

               for (int i = 1; i < i_BinaryNumberArray.Length; i++)
               {
                    if (currentMax.ToDecimalNumber() < i_BinaryNumberArray[i].ToDecimalNumber())
                    {
                         currentMax = i_BinaryNumberArray[i];
                    }
               }

               return currentMax;
          }

          public static BinaryNumber GetMin(BinaryNumber[] i_BinaryNumberArray)
          {
               BinaryNumber currentMin = i_BinaryNumberArray[0];

               for (int i = 1; i < i_BinaryNumberArray.Length; i++)
               {
                    if (currentMin.ToDecimalNumber() > i_BinaryNumberArray[i].ToDecimalNumber())
                    {
                         currentMin = i_BinaryNumberArray[i];
                    }
               }

               return currentMin;
          }









          public enum eBinaryDigit
          {
               One,
               Zero
          }

          private string m_StrBinaryNum;

          public BinaryNumber(string i_strBinaryNum)
          {
               m_StrBinaryNum = i_strBinaryNum;
          }

          private int GetNumOfCharOccurrences(char i_ch)
          {
               int numOfOccurrences = 0;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == i_ch)
                    {
                         numOfOccurrences++;
                    }
               }

               return numOfOccurrences;
          }

          public int GetNumberOfBinaryDigitOccurrences(eBinaryDigit i_digit)
          {
               int occurrences = 0;
               char charDigit = '0';

               if (i_digit == eBinaryDigit.One)
               {
                    charDigit = '1';
               }

               if (i_digit == eBinaryDigit.Zero)
               {
                    charDigit = '0';
               }

               occurrences = GetNumOfCharOccurrences(charDigit);

               return occurrences;
          }

          public bool IsPowerOfTwo()
          {
               bool seenOneSetDigit = false;
               bool isPowerOfTwo = false;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == '1')
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

          public static BinaryNumber Parse(string i_Str)
          {
               return new BinaryNumber(i_Str);
          }

          public static bool TryParse(string i_Str, out BinaryNumber o_BinaryNumber)
          {
               bool isParseable;

               if (IsBinaryNumber(i_Str))
               {
                    o_BinaryNumber = new BinaryNumber(i_Str);
                    isParseable = true;
               }
               else
               {
                    o_BinaryNumber = null;
                    isParseable = false;
               }

               return isParseable;
          }

          public static bool IsBinaryNumber(string i_Str)
          {
               bool res;

               if (isOnlyOnesAndZeros(i_Str))
               {
                    res = true;
               }
               else
               {
                    res = false;
               }

               return res;
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








     }
}
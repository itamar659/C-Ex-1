using System;
using System.Text;

namespace B21_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            const int k_NumOfRequests = 3;

            Console.WriteLine($"Please enter {k_NumOfRequests} binary numbers with 7 digits:");
            string[] binaryArr = getNBinaryNumbersFromUser(k_NumOfRequests);

            Console.Write("The numbers you entered in decimal: ");
            printBinaryNumberArrInDecimal(binaryArr);
            printBinaryNumberArrStatistics(binaryArr);

            Console.WriteLine();
        }

        private static void printBinaryNumberArrInDecimal(string[] i_BinaryNumbers)
        {
            int[] decimalArr = parseToDecimalArr(i_BinaryNumbers);

            printDecimalNumbers(decimalArr);
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
            const bool v_BinaryNumberValid = true;
            bool isValidBinaryNumber = !v_BinaryNumberValid;
            string binaryNumber = "";

            while (!isValidBinaryNumber)
            {
                string userInput = Console.ReadLine();

                isValidBinaryNumber = isValidBinaryNumberInput(userInput);
                if (isValidBinaryNumberInput(userInput))
                {
                    binaryNumber = userInput;
                    isValidBinaryNumber = v_BinaryNumberValid;
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
            bool isValidInput = (i_BinaryNumberStr.Length == k_NumOfDigits) && isOnlyOnesAndZeros(i_BinaryNumberStr);

            return isValidInput;
        }

        private static bool isOnlyOnesAndZeros(string i_Str)
        {
            const bool v_IsContainOnesZeros = true;
            bool isValidBinaryNumber = v_IsContainOnesZeros;

            foreach (char currentCharInString in i_Str)
            {
                if (currentCharInString != '0' && currentCharInString != '1')
                {
                    isValidBinaryNumber = !v_IsContainOnesZeros;
                    break;
                }
            }

            return isValidBinaryNumber;
        }

        private static void printDecimalNumbers(int[] i_DecimalNumberArr)
        {
            StringBuilder decimalNumbersStrBuilder = new StringBuilder();

            foreach (int decimalNumber in i_DecimalNumberArr)
            {
                decimalNumbersStrBuilder.Append(decimalNumber);
                decimalNumbersStrBuilder.Append(' ');
            }

            Console.WriteLine(decimalNumbersStrBuilder);
        }

        private static int[] parseToDecimalArr(string[] i_BinaryNumberArr)
        {
            int[] decimalArr = new int[i_BinaryNumberArr.Length];

            for (int i = 0; i < i_BinaryNumberArr.Length; i++)
            {
                decimalArr[i] = convertBinaryToDecimal(i_BinaryNumberArr[i]);
            }

            return decimalArr;
        }

        private static int convertBinaryToDecimal(string i_BinaryNumber)
        {
            int decimalNumber = 0;

            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                decimalNumber += getDigitFromBinary(i_BinaryNumber, i_BinaryNumber.Length - i - 1) * (int)Math.Pow(2, i);
            }

            return decimalNumber;
        }

        private static int getDigitFromBinary(string i_BinaryNumber, int i_IndexInBinaryNumber)
        {
            int binaryDigit = i_BinaryNumber[i_IndexInBinaryNumber] - '0';

            return binaryDigit;
        }

        private static void printBinaryNumberArrStatistics(string[] i_BinaryNumberArr)
        {
            float avgOfZeros = getAvgOfZerosInBinaryNumbers(i_BinaryNumberArr);
            float avgOfOnes = getAvgOfOnesInBinaryNumbers(i_BinaryNumberArr);
            int numOfPower2Numbers = getNumberOfPower2Numbers(i_BinaryNumberArr);
            int numOfNumbersPresentedInAscendingOrder = getNumberOfBinaryNumberPresentedInAscendingOrder(i_BinaryNumberArr);
            int maxBinaryNumber = getMax(parseToDecimalArr(i_BinaryNumberArr));
            int minBinaryNumber = getMin(parseToDecimalArr(i_BinaryNumberArr));

            string statisticsStr = string.Format(
@"The average zeros: {0}
The average ones: {1}
Number of numbers that are power of 2: {2}
Number of numbers that their digits represent ascending order: {3}
Max is: {4}, Min is: {5}",
                 avgOfZeros,
                 avgOfOnes,
                 numOfPower2Numbers,
                 numOfNumbersPresentedInAscendingOrder,
                 maxBinaryNumber,
                 minBinaryNumber);

            Console.WriteLine(statisticsStr);
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
            const bool v_PowerOfTwo = true;

            return getNumberOfBinaryDigitOccurrences(i_BinaryNumber, eBinaryDigit.One) == 1 ? v_PowerOfTwo : !v_PowerOfTwo;
        }

        private static int getMax(int[] i_BinaryNumberArray)
        {
            int currentMax = i_BinaryNumberArray[0];

            for (int i = 1; i < i_BinaryNumberArray.Length; i++)
            {
                currentMax = Math.Max(currentMax, i_BinaryNumberArray[i]);
            }

            return currentMax;
        }

        private static int getMin(int[] i_BinaryNumberArray)
        {
            int currentMin = i_BinaryNumberArray[0];

            for (int i = 1; i < i_BinaryNumberArray.Length; i++)
            {
                currentMin = Math.Min(currentMin, i_BinaryNumberArray[i]);
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

            for (int i = 0; i < i_BinaryNumberArray.Length; i++)
            {
                totalZeros += getNumberOfBinaryDigitOccurrences(i_BinaryNumberArray[i], i_BinaryDigit);
            }

            return i_BinaryNumberArray.Length == 0 ? 0 : (float)totalZeros / i_BinaryNumberArray.Length;
        }

        private static int getNumberOfBinaryNumberPresentedInAscendingOrder(string[] i_BinaryNumberArray)
        {
            int numOfAscendingOrderNumbers = 0;

            foreach (string currentBinaryNumber in i_BinaryNumberArray)
            {
                if (isNumberDigitsInAscendingOrder(convertBinaryToDecimal(currentBinaryNumber)))
                {
                    numOfAscendingOrderNumbers++;
                }
            }

            return numOfAscendingOrderNumbers;
        }

        private static int getNumberOfBinaryDigitOccurrences(string i_BinaryNumber, eBinaryDigit i_BinaryDigit)
        {
            char binaryDigitAsChar = i_BinaryDigit == eBinaryDigit.One ? '1' : '0';

            return getNumOfCharOccurrences(i_BinaryNumber, binaryDigitAsChar);
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

        private static bool isNumberDigitsInAscendingOrder(int i_Number)
        {
            const bool v_AscendingOrder = true;
            bool isAscendingOrder;

            if (i_Number < 10)
            {
                isAscendingOrder = v_AscendingOrder;
            }
            else
            {
                int lastValue = i_Number % 10;
                i_Number /= 10;

                if (i_Number % 10 < lastValue)
                {
                    isAscendingOrder = isNumberDigitsInAscendingOrder(i_Number);
                }
                else
                {
                    isAscendingOrder = !v_AscendingOrder;
                }
            }

            return isAscendingOrder;
        }
    }
}
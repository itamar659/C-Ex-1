using System;
using System.Text;

namespace B21_Ex01_4
{
    class Program
    {
        public static void Main()
        {
            const int k_divider = 4;
            
            string inputStr = getUserInput();

            bool isUserInputStrPolindrom = isPolindrom(new StringBuilder(inputStr));
            Console.WriteLine(string.Format("The string {0} polindrom", isUserInputStrPolindrom ? "is" : "isn't"));

            if (int.TryParse(inputStr, out int inputStrAsInteger))
            {
                bool isDivisibleByDivider = isNumberDivisible(inputStrAsInteger, k_divider);
                Console.WriteLine(string.Format("The number {0} be divided by {1}", isDivisibleByDivider ? "can" : "can not", k_divider));
            }

            if (isStringContainLettersOnly(inputStr))
            {
                int uppercaseLettersInStr = countUpperCase(inputStr);
                Console.WriteLine(string.Format("The number has {0} uppercase letters", uppercaseLettersInStr));
            }
        }

        private static string getUserInput()
        {
            const int k_stringSize = 10;
            string inputStr = "";
            bool isValidInput = false;

            Console.WriteLine(string.Format("Please Enter a string with {0} characters:", k_stringSize));
            Console.WriteLine("The string need to contain only letters or only numbers.");

            while (!isValidInput)
            {
                inputStr = Console.ReadLine();
                isValidInput = isValidString(inputStr) && inputStr.Length == k_stringSize;
                if (!isValidInput)
                {
                    Console.WriteLine("Something went wrong. Please try again.");
                }
            }

            return inputStr;
        }

        private static bool isValidString(string i_Str)
        {
            return isStringContainLettersOnly(i_Str) || isStringContainDigitsOnly(i_Str);
        }

        private static bool isStringContainLettersOnly(string i_Str)
        {
            return isStringContainRangeASCIIValues(i_Str.ToLower(), 'a', 'z');
        }

        private static bool isStringContainDigitsOnly(string i_Str)
        {
            return isStringContainRangeASCIIValues(i_Str, '0', '9');
        }

        private static bool isStringContainRangeASCIIValues(string i_Str, char i_Min, char i_Max)
        {
            bool isInputString = true;

            foreach (char currentCharInStr in i_Str)
            {
                if (!(i_Min <= currentCharInStr && currentCharInStr <= i_Max))
                {
                    isInputString = false;
                    break;
                }
            }

            return isInputString;
        }

        private static bool isPolindrom(StringBuilder i_Str)
        {
            bool isPoli = false;
            int strLength = i_Str.Length;

            if (strLength <= 1)
            {
                isPoli = true;
            }
            else if (i_Str[0] == i_Str[strLength - 1])
            {
                i_Str.Remove(strLength - 1, 1);
                i_Str.Remove(0, 1);
                isPoli = isPolindrom(i_Str);
            }

            return isPoli;
        }

        private static bool isNumberDivisible(int i_Number, int i_Divider)
        {
            bool isDivisible = false;

            if (i_Number % i_Divider == 0)
            {
                isDivisible = true;
            }

            return isDivisible;
        }

        private static int countUpperCase(string i_Str)
        {
            int countUpperCaseLetters = 0;

            foreach (char currentCharInStr in i_Str)
            {
                if (isStringContainRangeASCIIValues(currentCharInStr.ToString(), 'A', 'Z'))
                {
                    countUpperCaseLetters++;
                }
            }

            return countUpperCaseLetters;
        }
    }
}

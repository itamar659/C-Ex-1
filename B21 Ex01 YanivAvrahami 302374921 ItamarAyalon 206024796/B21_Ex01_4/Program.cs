using System;
using System.Text;

namespace B21_Ex01_4
{
    class Program
    {
        public static void Main()
        {
            const int k_Divider = 4;

            string inputStr = getUserInput();
            bool isUserInputStrPalindrome = isPalindrome(new StringBuilder(inputStr));

            Console.WriteLine(string.Format("The string {0} palindrome", isUserInputStrPalindrome ? "is" : "isn't"));

            if (float.TryParse(inputStr, out float inputStrAsInteger))
            {
                bool isDivisibleByDivider = inputStrAsInteger % k_Divider == 0;

                Console.WriteLine(string.Format("The number {0} be divided by {1}", isDivisibleByDivider ? "can" : "can not", k_Divider));
            }

            if (isStringContainLettersOnly(inputStr))
            {
                int uppercaseLettersInStr = countUpperCase(inputStr);

                Console.WriteLine(string.Format("The number has {0} uppercase letters", uppercaseLettersInStr));
            }
        }

        private static string getUserInput()
        {
            const int k_StringSize = 10;
            string inputStr = "";
            bool isValidInput = false;

            Console.WriteLine(string.Format("Please Enter a string with {0} characters:", k_StringSize));
            Console.WriteLine("The string need to contain only letters or only numbers.");

            while (!isValidInput)
            {
                inputStr = Console.ReadLine();
                isValidInput = isValidString(inputStr) && inputStr.Length == k_StringSize;
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

        private static bool isStringContainRangeASCIIValues(string i_Str, char i_MinASCIIValue, char i_MaxASCIIValue)
        {
            bool isInputString = true;

            foreach (char currentCharInStr in i_Str)
            {
                if (!(i_MinASCIIValue <= currentCharInStr && currentCharInStr <= i_MaxASCIIValue))
                {
                    isInputString = false;
                    break;
                }
            }

            return isInputString;
        }

        private static bool isPalindrome(StringBuilder i_Str)
        {
            bool isPalindromeBool = false;
            int strLength = i_Str.Length;

            if (strLength <= 1)
            {
                isPalindromeBool = true;
            }
            else if (i_Str[0] == i_Str[strLength - 1])
            {
                i_Str.Remove(strLength - 1, 1);
                i_Str.Remove(0, 1);
                isPalindromeBool = isPalindrome(i_Str);
            }

            return isPalindromeBool;
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

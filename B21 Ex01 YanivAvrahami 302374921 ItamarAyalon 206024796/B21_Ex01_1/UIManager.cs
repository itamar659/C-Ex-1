using System;

namespace B21_Ex01_1
{
    public class UIManager
    {
        private const uint k_NumOfNumbers = 3;
        private const uint k_NumOfDigits = 7;

        public void LaunchUI()
        {
            BinaryNumber[] binaryNumbers = new BinaryNumber[k_NumOfNumbers];

            Console.WriteLine("Please enter 3 numbers in a binary format.");
            for (int i = 0; i < k_NumOfNumbers; i++)
            {
                binaryNumbers[i] = getBinaryNumbersFromUser();
            }

            float avgOfZeors = BinaryNumberUtiles.GetAvgOfZerosInBinaryNumbers(binaryNumbers);
            Console.WriteLine(string.Format("The average zeros: {0}", avgOfZeors));



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
    }
}
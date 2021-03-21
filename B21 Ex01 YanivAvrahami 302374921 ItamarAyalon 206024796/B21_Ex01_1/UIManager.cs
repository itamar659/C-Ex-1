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

            Console.WriteLine("Please enter 3 number in a binary format");
            for (int i = 0; i < k_NumOfNumbers; i++)
            {
                binaryNumbers[i] = getBinaryNumbersFromUser();
            }



        }

        private BinaryNumber getBinaryNumbersFromUser()
        {
            string binaryNumberStr;

            do
            {
                binaryNumberStr = Console.ReadLine();
            } while (!isBNumberValidInput(binaryNumberStr));

            BinaryNumber binaryNumber = new BinaryNumber(binaryNumberStr);

            return binaryNumber;
        }

        private bool isBNumberValidInput(string i_binaryNumberStr)
        {
            return (i_binaryNumberStr.Length == k_NumOfDigits) && BinaryNumber.IsBinaryNumber(i_binaryNumberStr);
        }
    }
}

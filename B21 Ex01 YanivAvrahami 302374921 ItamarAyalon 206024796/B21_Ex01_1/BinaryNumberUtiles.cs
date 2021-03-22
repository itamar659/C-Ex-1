using System;

namespace B21_Ex01_1
{
    public class BinaryNumberUtiles
    {
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
                if (NumberUtiles.IsNumberDigitsInDecendingOrder(currentBinaryNumber.ToDecimalNumber()) == true)
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
    }
}

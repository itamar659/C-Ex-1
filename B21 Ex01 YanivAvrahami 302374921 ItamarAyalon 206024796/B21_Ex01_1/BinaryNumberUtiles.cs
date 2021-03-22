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
    }
}

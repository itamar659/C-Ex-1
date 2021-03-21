namespace B21_Ex01_1
{
    public class BinaryNumberUtiles
    {
        public static float GetAvgOfZerosInBinaryNumbers(BinaryNumber[] i_BinaryNumberArray)
        {
            int totalZeros = 0;
            float avgOfZeros = 0;

            for (int i = 0; i < i_BinaryNumberArray.Length; i++)
            {
                totalZeros += i_BinaryNumberArray[i].GetNumberOfZeros();
            }

            if (i_BinaryNumberArray.Length != 0)
            {
                avgOfZeros = (float)totalZeros / i_BinaryNumberArray.Length;
            }

            return avgOfZeros;
        }


        // TODO: Remove this piece of shit! copy-paste
        public static float GetAvgOfOnesInBinaryNumbers(BinaryNumber[] i_BinaryNumberArray)
        {
            int totalZeros = 0;
            float avgOfZeros = 0;

            for (int i = 0; i < i_BinaryNumberArray.Length; i++)
            {
                totalZeros += i_BinaryNumberArray[i].GetNumberOfOnes();
            }

            if (i_BinaryNumberArray.Length != 0)
            {
                avgOfZeros = (float)totalZeros / i_BinaryNumberArray.Length;
            }

            return avgOfZeros;
        }
    }
}

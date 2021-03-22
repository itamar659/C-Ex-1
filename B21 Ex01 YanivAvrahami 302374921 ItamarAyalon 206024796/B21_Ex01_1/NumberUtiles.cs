using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex01_1
{
    public class NumberUtiles
    {
        public static bool IsNumberDigitsInDecendingOrder(int i_Number)
        {
            bool isDecendingOrder;

            if (i_Number < 10)
            {
                isDecendingOrder = true;
            }
            else
            {
                int lastValue = i_Number % 10;
                i_Number /= 10;

                if (i_Number % 10 < lastValue)
                {
                    isDecendingOrder = IsNumberDigitsInDecendingOrder(i_Number);
                }
                else
                {
                    isDecendingOrder = false;
                }
            }

            return isDecendingOrder;
        }
    }
}

using System;

namespace B21_Ex01_1
{
     public class BinaryNumber
     {
          private string m_StrBinaryNum;

          public BinaryNumber(string strBinaryNum) 
          {
               m_StrBinaryNum = strBinaryNum;
          }
          
          public int GetNumberOfZeros()
          {
               int numOfZeros = 0;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == '0')
                    {
                         numOfZeros++;
                    }
               }

               return numOfZeros;
          }

          public int GetNumberOfOnes()
          {
               int numOfOnes = 0;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == '1')
                    {
                         numOfOnes++;
                    }
               }

               return numOfOnes;
          }

         /* public bool IsPowerOfTwo() 
          {
               bool seenOneSetDigit = false;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == '1')
                    {
                         if (seenOneSetDigit)
                         {
                              
                         }
                         seenOneSetDigit = true;
                    }


                    
               }
          }
*/
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
using System;

namespace B21_Ex01_1
{
     public class BinaryNumber
     {
          public enum eBinaryDigit
          {
               One,
               Zero
          }

          private string m_StrBinaryNum;

          public BinaryNumber(string strBinaryNum) 
          {
               m_StrBinaryNum = strBinaryNum;
          }

          private int GetNumOfCharOccurrences(char ch) 
          {
               int numOfOccurrences = 0;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == ch)
                    {
                         numOfOccurrences++;
                    }
               }

               return numOfOccurrences;
          }
     
          public int GetNumberOfBinaryDigitOccurrences(eBinaryDigit digit)
          {
               int occurrences = 0;
               char charDigit = '0';

               if (digit == eBinaryDigit.One)
               {
                    charDigit = '1';
               }

               if (digit == eBinaryDigit.Zero) 
               {
                    charDigit = '0';
               }

               occurrences = GetNumOfCharOccurrences(charDigit);
               
               return occurrences;
          }

          public bool IsPowerOfTwo() 
          {
               bool seenOneSetDigit = false;
               bool isPowerOfTwo = false;

               for (int i = 0; i < m_StrBinaryNum.Length; i++)
               {
                    if (m_StrBinaryNum[i] == '1')
                    {
                         if (seenOneSetDigit)
                         {
                              isPowerOfTwo = false;
                              break;
                         }
                         else
                         {
                              isPowerOfTwo = true;
                              seenOneSetDigit = true;
                         }
                    }
               }

               return isPowerOfTwo;
          }

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
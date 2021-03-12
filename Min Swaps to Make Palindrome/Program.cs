using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Swaps_to_Make_Palindrome
{
    class Program
    {
        public static void Main(string[] args)
        {
            Solution("madma");
        }

        public static int Solution(string s)
        {
            int minSwap = 0;
            //Length of string
            int len = s.Length;
            //Convert string to char array
            char[] charArray = s.ToCharArray();

            //Loop through half of the string as other half will be same but flipped
            for (int i = 0; i < len / 2; i++)
            {
                //left Pointer
                int left = i;
                //Right Pointer
                int right = len - left - 1;

                //Loop through right to left pointer and perform swapping
                while (left < right)
                {
                    //if both characters at the position are same, this loop will break, else will move from right to left to check if we have same character
                    //as Left position
                    if (s[left] == s[right])
                    {
                        break;
                    }
                    else
                    {
                        right--;
                    }
                }
                //If both pointers will end up at the same position, we don't have enough characters to make string polindrom
                if (left == right)
                {
                    return -1;
                }
                else
                {
                    for (int j = right; j < len - left - 1; j++)
                    {
                        char t = charArray[j];
                        charArray[j] = charArray[j + 1];
                        charArray[j + 1] = t;
                        minSwap++;
                    }
                }
            }

            return minSwap;
        }
    }
}

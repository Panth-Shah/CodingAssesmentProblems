using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Deletions_to_Make_Character_Frequencies_Unique
{
    //LeetCode Problem: 1647. Minimum Deletions to Make Character Frequencies Unique
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution sln = new Solution();
            sln.MinDeletions("accdcdadddbaadbc");

        }
    }
    internal class Solution
    {
        public int MinDeletions(string s)
        {
            int[] charArray = new int[26];
            int[] inverstedArray = new int[s.Length+1];
            var strArray = s.ToCharArray();
            if (s.Length == 0 || s == null)
            {
                return 0;
            }

            foreach(char ch in strArray)
            {
                charArray[ch - 'a'] += 1;
            }

            foreach (int i in charArray)
            {
                inverstedArray[i]++;
            }

            //If more than 1 characters have the same frequence, we will need to keep one character and reduce frequence
            //of another character/s. For example, if we have "aaabbbccc", we will have invertedArray[3] = 3
            //From here, we will need to reduce frequency of two characters to 1 and 2 respectively such that string can become a Good String.
            //As a result, we will need to find minimum delete. So in this example, we will have minimum delete 3 to reduce total characters from
            //9 to 6 with frequence of 3 2 1 respectively.

            //Distribution of each character has to be different and so in value at invertedArray[i] = 1
            int used = 0, reduce = 0;
            for (int i = s.Length; i > 0; i--)
            {
                if (inverstedArray[i] == 1)
                {
                    used += i;
                }
                else if (inverstedArray[i] > 1)
                {
                    reduce += inverstedArray[i] - 1;
                    used += i;
                }
                else if (inverstedArray[i]==0 && reduce>0)
                {
                    inverstedArray[i] = 1;
                    reduce--;
                    used += i;
                }
            }

            return s.Length - used;
        }
    }
}

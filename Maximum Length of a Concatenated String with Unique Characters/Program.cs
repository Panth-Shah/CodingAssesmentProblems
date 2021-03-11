using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Length_of_a_Concatenated_String_with_Unique_Characters
{
    class Program
    {
        //arr = ["un","iq","ue"]
        //All Possible: "","un","iq","ue","uniq" and "ique"
        //Answer: 4
        static void Main(string[] args)
        {
            Program p = new Program();
            p.MaxLengthS2(new List<string>() { "un", "iq", "ue" });
        }
        #region Solution using DFS
        public int MaxLength(IList<string> arr)
        {
            if (arr == null || arr.Count == 0) return 0;
            var len = arr.Count;

            //Run DFS
            var maxLength = 0;
            //Keep track of all the characters in the array
            var set = new HashSet<char>();
            runDFS(arr, 0, set, ref maxLength);
            return maxLength;
        }
        private void runDFS(IList<string> arr, int index, HashSet<char> set, ref int maxLength)
        {
            if (index >= arr.Count || set.Count == 26)
            {
                if (set.Count > maxLength)
                {
                    maxLength = set.Count;
                }
                return;
            }
            //Capture current word
            var current = arr[index];
            var currentSet = new HashSet<char>(current);

            currentSet.UnionWith(set);
            if (currentSet.Count == current.Length + set.Count)
            {
                runDFS(arr, index, currentSet, ref maxLength);
            }

            //skip the current element
            runDFS(arr, index + 1, set, ref maxLength);
        }
        #endregion

        #region Solution 2 using Backtracking
        public int MaxLengthS2(IList<string> arr)
        {
            // can we use recursion to either pick a string or leave it, we are only able to pick it if it has unique characters
            // we most likely will have to keep a character count, hash of character to count

            // we can pick or leave un
            // pick un
            // pick iq
            // must leave ue, base case so return num chars
            return MaxLength(arr, new int[26], 0);

        }

        private int MaxLength(IList<string> arr, int[] counts, int index)
        {
            // base case is if index goes out of range
            if (index >= arr.Count) return 0;

            // we can not pick
            int max = MaxLength(arr, counts, index + 1);

            string s = arr[index];
            for (int i = 0; i < s.Length; i++)
            {
                int charIndex = s[i] - 'a';
                if (counts[charIndex] != 0)
                {
                    // walk it back
                    i--;
                    while (i >= 0)
                    {
                        charIndex = s[i] - 'a';
                        counts[charIndex]--;
                        i--;
                    }

                    return max;
                }

                counts[charIndex] += 1;
            }

            // or we can pick
            max = Math.Max(max, s.Length + MaxLength(arr, counts, index + 1));

            for (int i = 0; i < s.Length; i++)
            {
                int charIndex = s[i] - 'a';
                counts[charIndex] -= 1;
            }

            return max;
        }
        #endregion

        #region Solution 3 using Backtracking
        public int MaxLengthS3(IList<string> arr)
        {
            return Backtracking(arr, 0, new StringBuilder());
        }

        private int Backtracking(IList<string> arr, int index, StringBuilder curr)
        {
            if (index >= arr.Count)
            {
                return curr.Length;
            }

            int maxLength = Backtracking(arr, index + 1, curr);
            StringBuilder tmp = new StringBuilder();
            tmp.Append(curr.ToString());
            tmp.Append(arr[index]);
            if (IsValid(tmp.ToString()))
            {
                maxLength = Math.Max(
                    maxLength,
                    Backtracking(arr, index + 1, tmp));
            }

            return maxLength;
        }

        private bool IsValid(string s)
        {
            HashSet<char> seen = new HashSet<char>();
            foreach (char c in s)
            {
                if (seen.Contains(c))
                {
                    return false;
                }

                seen.Add(c);
            }

            return true;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class LongestSubstring
    {
        int[,] LCS;
        public void Execute()
        {
            String A = "tutorialhorizon";
            String B = "dynamictutorialProgramming";
            int result = LongestCommonSubstring(A, B);
            Console.Write("Length of Longest Common Substring: " + result+" ('");
            PrintSolution(A, LCS);
            Console.Write("')");
            Console.Read();
        }
        private int LongestCommonSubstring(String A, String B)
        {
            LCS = new int[A.Length + 1, B.Length + 1];
            for (int i = 0; i <= A.Length; i++)
            {
                LCS[i, 0] = 0;
            }
            for (int j = 1; j <= B.Length; j++)
            {
                LCS[0, j] = 0;
            }
            for (int i = 1; i <= A.Length; i++)
            {
                for (int j = 1; j <= B.Length; j++)
                {
                    if (A[i - 1] == B[j - 1])
                    {
                        LCS[i, j] = LCS[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        LCS[i, j] = 0;
                    }
                }
            }
            return Common.ArrayMax(LCS);
        }
        private void PrintSolution(string A, int[,] LCS)
        {
            int maxI = 0;
            int maxJ = 0;
            int maxValue = int.MinValue;
            for (int i = 0; i < LCS.GetLength(0); i++)
            {
                for (int j = 0; j < LCS.GetLength(1); j++)
                {
                    if (maxValue < LCS[i, j])
                    {
                        maxValue = LCS[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }
            PrintSubstring(A, LCS, maxI, maxJ);
        }
        private void PrintSubstring(string A, int[,] LCS, int i, int j)
        {
            if(LCS[i,j]==0)
            {
                return;
            }
            else
            {
                PrintSubstring(A, LCS, i-1, j-1);
                Console.Write(A[i-1]);
            }
        }
    }
}

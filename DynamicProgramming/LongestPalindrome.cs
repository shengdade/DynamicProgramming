using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class LongestPalindrome
    {
        private int n;
        private char[,] S;
        private char downwardsArrow = Convert.ToChar(8595);
        private char leftwardsArrow = Convert.ToChar(8592);
        private char southwestArrow = Convert.ToChar(8601);
        private int middleStart;
        private int middleEnd;
        public void Execute()
        {
            String strA = "AABCDEBAZ";
            int result = FindPalindrome(strA);
            Console.WriteLine("Length of Longest Palindrome in '" + strA + "' is: " + result);
            Console.WriteLine("The Palindromic Sequences are:");
            Console.Write("1. ");
            PrintSolution(strA, S, 0, n - 1, 0);
            for (int k = 1; k < middleEnd - middleStart; k++)
            {
                Console.WriteLine();
                Console.Write((k + 1) + ". ");
                PrintSolution(strA, S, 0, n - 1, k);
            }
            Console.Read();
        }
        private int FindPalindrome(String A)
        {
            n = A.Length;
            int[,] LP = new int[n, n];
            S = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                LP[i, i] = 1;
            }
            for (int sublen = 2; sublen <= n; sublen++)
            {
                for (int i = 0; i <= n - sublen; i++)
                {
                    int j = i + sublen - 1;
                    if (A[i] == A[j])
                    {
                        LP[i, j] = LP[i + 1, j - 1] + 2;
                        S[i, j] = southwestArrow;
                    }
                    else
                    {
                        if (LP[i, j - 1] >= LP[i + 1, j])
                        {
                            LP[i, j] = LP[i, j - 1];
                            S[i, j] = leftwardsArrow;
                        }
                        else
                        {
                            LP[i, j] = LP[i + 1, j];
                            S[i, j] = downwardsArrow;
                        }
                    }
                }
            }
            return LP[0, n - 1];
        }
        private void PrintSolution(String A, char[,] S, int i, int j, int k)
        {
            if (i == j)
            {
                if (k == 0)
                {
                    middleStart = j;
                }
                Console.Write(A[i + k]);
                return;
            }
            else
            {
                if (S[i, j] == southwestArrow)
                {
                    if (k == 0)
                    {
                        middleEnd = j;
                    }
                    Console.Write(A[i]);
                    PrintSolution(A, S, i + 1, j - 1, k);
                    Console.Write(A[i]);
                }
                else if (S[i, j] == downwardsArrow)
                {
                    PrintSolution(A, S, i + 1, j, k);
                }
                else if (S[i, j] == leftwardsArrow)
                {
                    PrintSolution(A, S, i, j - 1, k);
                }
            }
        }
    }
}

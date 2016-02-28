using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class NumberSquares
    {
        int[] S;
        public void Execute()
        {
            int n = 12345;
            int result = MinimumNumberSquares(n);
            Console.WriteLine("Minimum number of squares for " + n + " is: " + result);
            Console.Write("These integers are: ");
            PrintSolution(S, n);
            Console.Read();
        }
        private int MinimumNumberSquares(int n)
        {
            int[] MN = new int[n + 1];
            S = new int[n + 1];
            MN[0] = 0;
            S[0] = 0;
            int k;
            double m;
            for (int j = 1; j <= n; j++)
            {
                k = (int)Math.Sqrt((double)j);
                if (k * k == j)
                {
                    MN[j] = 1;
                    S[j] = k;
                }
                else
                {
                    m = double.PositiveInfinity;
                    for (int i = 1; i <= k; i++)
                    {
                        if (MN[j - i * i] + 1 < m)
                        {
                            m = MN[j - i * i] + 1;
                            S[j] = i;
                        }
                    }
                    MN[j] = (int)m;
                }
            }
            return MN[n];
        }
        private void PrintSolution(int[] S, int k)
        {
            if (k == S[k] * S[k])
            {
                Console.Write(S[k] + " ");
            }
            else
            {
                PrintSolution(S, k - S[k] * S[k]);
                Console.Write(S[k] + " ");
            }
            //while (k > 0)
            //{
            //    Console.Write(S[k] + " ");
            //    k -= S[k] * S[k];
            //}
        }
    }
}

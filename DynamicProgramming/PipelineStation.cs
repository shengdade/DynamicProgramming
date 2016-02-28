using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class PipelineStation
    {
        int[] s;
        public void Execute()
        {
            int n = 4;
            int[] b = new int[] { 0, 1, 1, 0 };
            int[,] c = new int[,] { { 0, 2, 8, 10 }, { 0, 0, 1, 8 }, { 0, 0, 0, 2 }, { 0, 0, 0, 0 } };
            double result = DynamicPipelineStation(n, b, c);
            Console.WriteLine(String.Format("The minimum cost would be: {0}", result));
            Console.Write("The places to build stations: ");
            PrintSolution(n, s);
            Console.Read();
        }
        private double DynamicPipelineStation(int n, int[] b, int[,] c)
        {
            double[] r = new double[n];
            s = new int[n];
            Common.FillArray(r, double.PositiveInfinity);
            Common.FillArray(s, 0);
            r[0] = 0;
            for (int k = 1; k < n; k++)
            {
                for (int i = 0; i < k; i++)
                {
                    if (r[i] + b[i] + c[i, k] < r[k])
                    {
                        r[k] = r[i] + b[i] + c[i, k];
                        s[k] = i + 1;
                    }
                }
            }
            return r[n - 1];
        }
        private void PrintSolution(int n, int[] s)
        {
            if (s[n - 1] == 1)
            {
                return;
            }
            else
            {
                PrintSolution(s[n - 1], s);
                Console.Write(s[n - 1] + " ");
            }
            //while (s[n - 1] != 1)
            //{
            //    Console.Write(s[n - 1] + " ");
            //    n = s[n - 1];
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class ProductCutting
    {
        public void Execute()
        {
            int n = 7;
            double result = MaximumProductCutting(n);
            Console.Write("Maximum product cutting in " + n + " is: " + result);
            Console.Read();
        }
        private double MaximumProductCutting(int n)
        {
            double[] MPC = new double[n + 1];
            double mp;
            MPC[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                mp = double.NegativeInfinity;
                for (int k = 1; k < i; k++)
                {
                    mp = Math.Max(mp, Math.Max(MPC[k] * (i - k), k * (i - k)));
                }
                MPC[i] = mp;
            }
            return MPC[n];
        }
    }
}


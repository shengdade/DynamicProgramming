using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class BinomialCoefficients
    {
        public void Execute()
        {
            int n = 8;
            int k = 3;
            int result = DynamicBinomialCoefficients(n, k);
            Console.Write(String.Format("{0} choose {1} is: {2}", n, k, result));
            Console.Read();
        }
        private int DynamicBinomialCoefficients(int n, int k)
        {
            int[,] myArray = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                myArray[i, 0] = 1;
                myArray[i, i] = 1;
            }
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    myArray[i, j] = myArray[i - 1, j] + myArray[i - 1, j - 1];
                }
            }
            Common.PrintTable(myArray);
            return myArray[n, k];
        }
    }
}

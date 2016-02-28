using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class StirlingNumbers2
    {
        public void Execute()
        {
            int n = 4;
            int k = 3;
            int result = StirlingNumbersSecond(n, k);
            Console.Write(String.Format("Ways to partition a set of {0} objects into {1} non-empty subsets: {2}", n, k, result));
            Console.Read();
        }
        private int StirlingNumbersSecond(int n, int k)
        {
            int[,] myArray = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                myArray[i, 0] = 0;
                myArray[0, i] = 0;
            }
            myArray[0, 0] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    myArray[i, j] = j * myArray[i - 1, j] + myArray[i - 1, j - 1];
                }
            }
            Common.PrintTable(myArray);
            return myArray[n, k];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    static class Common
    {
        private static void Main(string[] args)
        {
            //BinomialCoefficients bc = new BinomialCoefficients();
            //bc.Execute();
            //PipelineStation ps = new PipelineStation();
            //ps.Execute();
            //LongestPalindrome lp = new LongestPalindrome();
            //lp.Execute();
            //ProductCutting pc = new ProductCutting();
            //pc.Execute();
            //NumberSquares ns = new NumberSquares();
            //ns.Execute();
            //LongestSubstring ls = new LongestSubstring();
            //ls.Execute();
            //MinimumCostPath mcp = new MinimumCostPath();
            //mcp.Execute();
            StirlingNumbers2 sn = new StirlingNumbers2();
            sn.Execute();
        }
        public static void PrintTable<T>(this T[,] ArrayToPrint)
        {
            int m = ArrayToPrint.GetLength(0);
            int n = ArrayToPrint.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Format("{0}\t", ArrayToPrint[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrintTable<T>(this T[] ArrayToPrint)
        {
            int n = ArrayToPrint.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                Console.Write(String.Format("{0}\t", ArrayToPrint[i]));
            }
            Console.WriteLine();
        }
        public static void FillArray<T>(this T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
        public static int ArrayMax(int[,] array)
        {
            int result = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (result < array[i, j])
                        result = array[i, j];
                }
            }
            return result;
        }
    }
}
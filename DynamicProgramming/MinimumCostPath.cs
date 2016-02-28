using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class MinimumCostPath
    {
        public void Execute()
        {
            int[,] map = new int[,] { { 1, 7, 9, 2 }, { 8, 6, 3, 2 }, { 1, 6, 7, 8 }, { 2, 9, 8, 2 } };
            Console.Write("Minimum Cost Path: " + MinimumCost(map));
            Console.Read();
        }
        private int MinimumCost(int[,] map)
        {
            int[,] MCP = new int[map.GetLength(0), map.GetLength(1)];
            MCP[0, 0] = map[0, 0];
            for (int i = 1; i < MCP.GetLength(0); i++)
            {
                MCP[i, 0] = MCP[i - 1, 0] + map[i, 0];
            }
            for (int j = 1; j < MCP.GetLength(1); j++)
            {
                MCP[0, j] = MCP[0, j - 1] + map[0, j];
            }
            for (int i = 1; i < MCP.GetLength(0); i++)
            {
                for (int j = 1; j < MCP.GetLength(1); j++)
                {
                    MCP[i, j] = Math.Min(MCP[i, j - 1], MCP[i - 1, j]) + map[i, j];
                }
            }
            return MCP[MCP.GetLength(0) - 1, MCP.GetLength(1) - 1];
        }
    }
}

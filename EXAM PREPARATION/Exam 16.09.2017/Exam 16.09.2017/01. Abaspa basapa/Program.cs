using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Abaspa_basapa
{
    class Program
    {
        static int[,] matrix;

        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            matrix = new int[first.Length + 1, second.Length + 1];
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = 0;
                    }
                }
            }
            int bestRow = 0;
            int bestCol = 0;
            int bestVal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > bestVal)
                    {
                        bestRow = row;
                        bestCol = col;
                        bestVal = matrix[row, col];
                    }
                }
            }

            Stack<char> results = new Stack<char>();
            int curRow = bestRow;
            int curCol = bestCol;
            while (matrix[curRow, curCol] > 0)
            {
                results.Push(first[curRow - 1]);
                curRow--;
                curCol--;
            }
            Console.WriteLine(new string(results.ToArray()));
        }
    }
}

namespace MoveDownRightSum
{
    using System;
    using System.Collections.Generic;

    public class Program
    {

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int[,] sumMatrix = new int[rows, cols];

            sumMatrix[0,0] = matrix[0, 0];

            //fill first row line in matrix

            for (int row = 1; row < rows; row++)
            {
                sumMatrix[row, 0] = sumMatrix[row - 1, 0] + matrix[row, 0]; 
            }

            //fill first col line in matrix

            for (int col = 1; col < cols; col++)
            {
                sumMatrix[0, col] = sumMatrix[0, col - 1] + matrix[0, col];
            }

            //fill all matrix

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    int result = Math.Max(sumMatrix[row, col - 1],
                                          sumMatrix[row - 1, col]);

                    sumMatrix[row, col] = result + sumMatrix[row - 1, col - 1];
                }
            }

            //Find path

            Console.WriteLine(" ");
            PrintMatrix(sumMatrix, rows, cols);

            List<string> sumPath = new List<string>();

            sumPath.Add($"[{rows - 1}, {cols - 1}]");

            int currentRow = rows - 1;
            int currentCol = cols - 1;

            while (currentRow != 0 || currentCol != 0)
            {
                int top = -1;
                int left = -1;

                if (currentRow - 1 >= 0)
                {
                    top = sumMatrix[currentRow - 1, currentCol];
                }

                if (currentCol - 1 >= 0)
                {
                    left = sumMatrix[currentRow, currentCol - 1];
                }
                
                if (top > left)
                {
                    sumPath.Add($"[{currentRow - 1}, {currentCol}]");
                    currentRow -= 1;
                }
                else
                {
                    sumPath.Add($"[{currentRow}, {currentCol - 1}]");
                    currentCol -= 1;
                }
            }

            sumPath.Reverse();
            Console.WriteLine(string.Join(" ", sumPath));

            

        }

        public static void PrintMatrix(int[,] matrix,int rows,int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }

}

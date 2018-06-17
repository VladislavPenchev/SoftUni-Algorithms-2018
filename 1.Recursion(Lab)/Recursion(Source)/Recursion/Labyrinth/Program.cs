using System;
using System.Collections.Generic;
using System.Linq;

namespace Labyrinth
{
    public class Program
    {
        static char[,] labyrinth;

        static List<char> path = new List<char>();

        static void ReadLabyrinth()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                string currentLine = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = currentLine[col];
                }
            }
        }

        static void Solve(int row,int col,char distination)
        {
            //outOfRange
            if (row < 0 || row >= labyrinth.GetLength(0)
                || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            path.Add(distination);

            if (labyrinth[row, col] == 'e')
            {
                    Console.WriteLine(string.Join(string.Empty, path.Skip(1)));                
            }
            else if (IsPassable(row, col))
            {
                labyrinth[row, col] = 'x';

                Solve(row, col + 1, 'R');
                Solve(row, col - 1, 'L');
                Solve(row + 1, col, 'D');
                Solve(row - 1, col, 'U');   

                labyrinth[row,col] = '-';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsPassable(int row, int col)
        {
            //already visited
            if (labyrinth[row, col] == 'x')
            {
                return false;
            }

            //wall
            if (labyrinth[row, col] == '*')
            {
                return false;
            }

            return true;
        }
         

        public static void Main()
        {
            ReadLabyrinth();
            Solve(0,0,'S');
        }
    }
}

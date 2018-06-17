namespace _1.Medenka
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string medenka = string.Join("", Console.ReadLine().Split());

            int nuts = GetNuts(medenka);

            int start = medenka.IndexOf('1');

            int cuts = 0;

            List<string> result = new List<string>();

            GenerateCuts(start, medenka, nuts, cuts, result);
        }

        static void GenerateCuts(int start, string medenka, int nuts, int cuts, List<string> result)
        {
            if (cuts + 1 == nuts)
            {
                //print
            }

            int end = medenka.IndexOf("1",start + 1);

            for (int i = start; i < end; i++)
            {
                result.Add(i);
                GenerateCuts(start,);
            }

        }

        static int GetNuts(string medenka)
        {
            int count = 0;

            for (int i = 0; i < medenka.Length; i++)
            {
                if (medenka[i] == '1')
                {
                    count++;
                }
            }

            return count;
        }
    }
}

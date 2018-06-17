using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Terran
{
    class Program
    {
        static int count;

        static char[] list;

        static Dictionary<char,int> elements = new Dictionary<char,int>();

        private static HashSet<string> visited = new HashSet<string>();

        

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            var letterCounter = input.Where(char.IsLetterOrDigit)
                          .GroupBy(char.ToLower)
                          .Select(counter => new { Letter = counter.Key, Counter = counter.Count() });

            foreach (var counter in letterCounter)
            {
                elements[counter.Letter] = counter.Counter;
                //Console.WriteLine(String.Format("{0} = {1}", counter.Letter, counter.Counter));
            }

            for (int i = 0; i < list.Length; i++)
            {

            }

        }


    }
}

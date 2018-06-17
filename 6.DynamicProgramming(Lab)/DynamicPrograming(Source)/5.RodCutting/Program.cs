namespace _5.RodCutting
{
    using System;
    using System.Collections.Generic;
    
    //0 1 2 3 4 
    //0 1 5 8 9 10 17 17 20 24 30
    //4
    class Program
    {
        static string[] priceOfRod = Console.ReadLine().Split();
        static int[] lengthOfRod = new int[priceOfRod.Length];

        public static int CuttingRod(int index)
        {
            if (index == 0)
            {
                return 1;
            }



            int result = CuttingRod(index - 1);

            return result;
        }

        static void Main(string[] args)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int index = 0; index < lengthOfRod.Length; index++)
            {
                lengthOfRod[index] = index;
            }


            for (int index = 0; index < priceOfRod.Length; index++)
            {
                dic.Add(lengthOfRod[index], int.Parse(priceOfRod[index]));
            }

            int findLengthOfRod = int.Parse(Console.ReadLine());

            CuttingRod(findLengthOfRod);


            HashSet<int> bestPrice = new HashSet<int>();
            HashSet<int> bestCut = new HashSet<int>();
            
        }
        
    }
}

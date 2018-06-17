namespace _1.SnapSack
{
    using System;
    using System.Collections.Generic;

    public class Program
    {   
        public static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            List<Item> items = new List<Item>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                var part = line.Split();

                items.Add(new Item
                {
                    Name = part[0],
                    Weigth = int.Parse(part[1]),
                    Price = int.Parse(part[2])
                });
            }

            var prices = new int[items.Count + 1, maxCapacity + 1];
            var itemsIncluded = new bool[items.Count + 1, maxCapacity + 1];

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                Item item = items[itemIndex];
                var rowIndex = itemIndex + 1;

                for (int capacity = 0; capacity <= maxCapacity; capacity++)
                {
                    if (item.Weigth > maxCapacity)
                    {
                        continue;
                    }

                    int excluding = prices[rowIndex - 1, capacity];
                    int including = item.Price + prices[rowIndex - 1, capacity - item.Weigth];

                    if (including > excluding)
                    {
                        prices[rowIndex, capacity] = including;
                        itemsIncluded[rowIndex, capacity] = true;
                    }
                    else
                    {
                        prices[rowIndex, capacity] = excluding;
;                    }


                }
            }

            


        }
    }
}

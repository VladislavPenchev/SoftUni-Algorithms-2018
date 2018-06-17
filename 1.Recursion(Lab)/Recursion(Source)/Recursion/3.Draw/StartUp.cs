namespace _2.Draw
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Draw(number);
        }

        private static void Draw(int count)
        {
            if (count == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', count));

            Draw(count - 1);

            Console.WriteLine(new string('#', count));

        }
    }
}

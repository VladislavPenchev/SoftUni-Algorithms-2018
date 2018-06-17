namespace _1.Fibonacci
{
    class Program
    {
        //interactive
        static int Fib(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            int result = Fib(n - 1) + Fib(n - 2);
            return result;
        }

        static void Main(string[] args)
        {
            
            System.Console.WriteLine(Fib(6));
        }
    }
}

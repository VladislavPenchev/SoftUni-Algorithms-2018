namespace _2.FibonacciDwnamicOptimizationWithArray
{
    class Program
    {
        static int[] numbers;

        static int Fib(int n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }            

            int result = Fib(n - 1) + Fib(n - 2);

            numbers[n] = result;

            return result;
        }

        static void Main(string[] args)
        {
            numbers = new int[100];
            System.Console.WriteLine(Fib(3));
        }
    }
}

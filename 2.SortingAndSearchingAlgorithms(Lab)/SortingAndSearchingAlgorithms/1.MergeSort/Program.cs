namespace _1.MergeSort
{
    public class Program
    {
        static void Sort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex <= endIndex)
            {
                return;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            Sort(arr, startIndex, middleIndex);
            Sort(arr, middleIndex + 1, endIndex);

        }

        public static void Main()
        {
            int[] numbers = new int[] { 5, 8, 1, 2, 4, 9 };

            Sort(numbers, 0, numbers.Length - 1);
        }
    }
}

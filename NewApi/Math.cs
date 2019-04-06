using System.Linq;
using Common;

namespace NewApi
{
    public static class Math
    {
        public static Result Summary(params int[] numbers)
        {
            return new Result
            {
                Largest = Largest(numbers),
                Average = Average(numbers),
                Smallest = Smallest(numbers),
                Sum      = Sum(numbers)
            };
        }

        public static int Sum(params int[] numbers)
        {
            return numbers.Sum();
        }

        public static int Largest(params int[] numbers)
        {
            return numbers.Max();
        }

        public static int Smallest(params int[] numbers)
        {
            return numbers.Min();
        }

        public static double Average(params int[] numbers)
        {
            return numbers.Average();
        }
    }
}
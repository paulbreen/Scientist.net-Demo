using Common;

namespace OldApi
{
    public static class Math
    {
        public static Result Summary(params int[] numbers)
        {
            return new Result
            {
                Largest  = Largest(numbers),
                Average  = Average(numbers),
                Smallest = Smallest(numbers),
                Sum      = Sum(numbers)
            };
        }

        public static int Sum(params int[] numbers)
        {
            var sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public static int Largest(params int[] numbers)
        {
            var largest = int.MinValue;

            foreach (var number in numbers)
            {
                if(number > largest)
                {
                    largest = number;
                }
            }

            return largest;
        }

        public static int Smallest(params int[] numbers)
        {
            var smallest = int.MaxValue;

            foreach (var number in numbers)
            {
                if (number < smallest)
                {
                    smallest = number;
                }
            }

            return smallest;
        }

        public static double Average(params int[] numbers)
        {
            var sum = Sum(numbers);

            return sum / numbers.Length;
        }
    }
}
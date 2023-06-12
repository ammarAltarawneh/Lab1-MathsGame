namespace Lab1_MathsGame
{
    using System.Runtime.InteropServices;
    
        class Program
        {
            static void Main(string[] args)
            {

            try
            {
                StartSequence();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"You have not enter a number: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"This is a huge number: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something wrong: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Program completed.");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero:");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[size];
            Populate(numbers);

            int sum = GetSum(numbers);
            int product = GetProduct(numbers, sum);
            decimal quotient = GetQuotient(product);

            Console.WriteLine($"The array size is: {size}");
            Console.WriteLine($"The array values are: {string.Join(", ", numbers)}");
            Console.WriteLine($"The sum of the array is: {sum}");

            try
            {
                Console.WriteLine($"The product of the random number index multiplied by the sum is: {product}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid index: {ex.Message}");
                throw;
            }


            Console.WriteLine($"The quotient of the product divided by the nmber you had chosen is: {quotient}");
        }

        static void Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter number {i + 1} of {numbers.Length}:");
                string input = Console.ReadLine();
                numbers[i] = Convert.ToInt32(input);
            }
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low.");
            }

            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine($"Please select a random number between 1 and {numbers.Length}:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index < 0 || index >= numbers.Length)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }

            return sum * numbers[index];
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product ({product}) by:");
            string x = Console.ReadLine();

            if (x == "0")
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0;
            }

            decimal dividend = Convert.ToDecimal(x);
            return decimal.Divide(product, dividend);

            }
        }
    
}
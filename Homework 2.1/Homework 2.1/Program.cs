using System.ComponentModel;

namespace Homework_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Enter count elements of array: ");
                if (!Int32.TryParse(Console.ReadLine(), out int countElements))
                {
                    Console.WriteLine("Invalid data entered");
                    return;
                }
                int[] arrRendomElements = new int[countElements];
                int resultCountElement = 0;
                    
                for (int i = 0; i < arrRendomElements.Length; i++)
                {
                    arrRendomElements[i] = new Random().Next(int.MinValue, int.MaxValue);
                }

                for (int i = 0; i < arrRendomElements.Length; i++)
                {
                    if (-100 <= arrRendomElements[i] && arrRendomElements[i] >= 100)
                    {
                        resultCountElement++;
                    }
                }

                Console.WriteLine($"the number of elements whose values are in the range -100 to +100 = {resultCountElement}");

            

            
                Console.WriteLine("Press any key, display cleared and restart");
                Console.ReadKey();
            }
        }
    }
}

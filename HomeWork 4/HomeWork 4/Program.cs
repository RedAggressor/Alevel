namespace HomeWork_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of array what you want to create at 0 for 255: ");

            Console.WriteLine();

            if (!byte.TryParse(Console.ReadLine(), out byte lengthArray) || lengthArray < 0 || lengthArray > byte.MaxValue)
            {
                Console.WriteLine($"Error!!! enter only numbers at 0 for {byte.MaxValue}!");

                return;
            }

            /* First array with rendom elemet from 1 to 26 value */

            int[] arrayOfNumbers = new int[lengthArray];

            CreateRandomElement(arrayOfNumbers);

            Console.WriteLine();

            Console.WriteLine("Display first array: ");

            DisplayShowIntArray(arrayOfNumbers);

            Console.WriteLine();

            /* Start create add work with Even number array and transfrom to char */

            int[] arrayEvenNumbers = new int[lengthArray];

            CreateEvenElementToArray(arrayEvenNumbers);

            char[] changeEvenArray = ChangeNumberToChar(arrayEvenNumbers);

            ChangeOnUpperCaseSpecificChar(changeEvenArray);

            int countCharUpperOfEven = CountOfUpperChar(changeEvenArray);

            Console.WriteLine("Displey Even char array with Upper: ");

            DisplayShowCharArray(changeEvenArray);

            Console.WriteLine();

            /* Start create add work with Odd number array and transfrom to char */

            int[] arrayOddNumbers = new int[lengthArray];

            CreateOddElementToArray(arrayOddNumbers);

            char[] changeOddArray = ChangeNumberToChar(arrayOddNumbers);

            ChangeOnUpperCaseSpecificChar(changeOddArray);

            int countCharUpperOfOdd = CountOfUpperChar(changeOddArray);

            Console.WriteLine("Displey Odd char array with Upper: ");

            DisplayShowCharArray(changeOddArray);

            Console.WriteLine();

            /* Compare two char array */

            Console.WriteLine($"array with even numbers have {countCharUpperOfEven} upper letter, array odd numbers have {countCharUpperOfOdd} upper letter");

            CompareTwoValues(countCharUpperOfEven, countCharUpperOfOdd);
        }

        static void DisplayShowIntArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        static void DisplayShowCharArray(char[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        static int[] CreateRandomElement(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(1, 27);
            }

            return array;
        }

        static int[] CreateEvenElementToArray(int[] array)
        {
            int randomNumber;

            for (int i = 0; i < array.Length; i++)
            {
                randomNumber = new Random().Next(1, 26);
                if (randomNumber % 2 == 0)
                {
                    array[i] = randomNumber;
                }
                else
                {
                     array[i] = randomNumber + 1;
                }
            }

            return array;
        }

        static int[] CreateOddElementToArray(int[] array)
        {
            int randomNumber;

            for (int i = 0; i < array.Length; i++)
            {
                randomNumber = new Random().Next(1, 26);
                if (randomNumber % 2 == 1)
                {
                    array[i] = randomNumber;
                }
                else
                {
                    array[i] = randomNumber + 1;
                }
            }

            return array;
        }

        static char[] ChangeNumberToChar(int[] array)
        {
            char[] arrayChar = new char[array.Length];

            int corectionChanged = 1;

            char countdownBegins = 'a';

            for (int i = 0; i < array.Length; i++)
            {
                arrayChar[i] = Convert.ToChar(countdownBegins + array[i] - corectionChanged); // 'a' the first char from which we look for the one we need by adding our number(array[i]) with a correction variable
            }

            return arrayChar;
        }

        static char[] ChangeOnUpperCaseSpecificChar(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (CheckSpecificChar(array[i]))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }

            return array;
        }

        static int CountOfUpperChar(char[] array)
        {
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (char.IsUpper(array[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        static bool CheckSpecificChar(char ch)
        {
            switch (ch)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'd':
                case 'h':
                case 'j':
                    return true;

                default:
                    return false;
            }
        }

        static void CompareTwoValues(int firstValue, int secondValue)
        {
            if (firstValue > secondValue)
            {
                Console.WriteLine("array with upper letter even numbers > array with upper letter odd numbers");
            }
            else if (firstValue == secondValue)
            {
                Console.WriteLine("array with upper letter even numbers = array with upper letter odd numbers");
            }
            else if (firstValue < secondValue)
            {
                Console.WriteLine("array with upper letter odd numbers > array with upper letter even numbers");
            }
        }
    }
}

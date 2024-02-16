using static HomeWork13.First;

namespace HomeWork13
{
    internal class Program
    {
        private static void Show(bool result)
        {
            Console.WriteLine($"result: {result}");
        }

        static void Main(string[] args)
        {
            Second second = new Second();

            int firstValue = 10;

            int secondValue = 5;

            var tig = second.Calc(firstValue, secondValue, First.Multiply);

            FirstHandler firstHandler = Show;

            int divisionByCompare = 3;

            firstHandler(tig(divisionByCompare));
        }
    }
}

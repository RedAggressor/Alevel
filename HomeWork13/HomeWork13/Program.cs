﻿using static HomeWork13.First;

namespace HomeWork13
{
    public class First
    {
        public delegate void FirstHandler(bool prob);

        public static int Multiply(int x, int y) => x * y;
    }

    public class Second
    {
        private int _result;

        public Predicate<int> Calc(int x, int y, Func<int, int, int> func)
        {
            _result = func(x, y);

            Predicate<int> predicate = Result;

            return predicate;
        }

        public bool Result(int x)
        {
            return _result % x == 0;
        }
    }
    internal class Program
    {
        static void Show(bool result)
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

            int divisionBy = 3;

            firstHandler(tig(divisionBy));
        }
    }
}

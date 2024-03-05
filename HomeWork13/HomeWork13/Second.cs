namespace HomeWork13
{
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
}

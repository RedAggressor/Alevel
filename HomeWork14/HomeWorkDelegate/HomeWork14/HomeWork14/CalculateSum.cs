namespace HomeWork14
{
    public delegate void CalculateSumHandler(string message);
    internal class CalculateSum
    {
        public event CalculateSumHandler? calculatorHandler;

        public int Caculate(int x, int y)
        {
            int result = WrapperMethod((a, b) => a + b, x, y);

            calculatorHandler?.Invoke($"Sum nuber {x} + {y} = {result}");

            return result;
        }

        private int WrapperMethod(Func<int, int, int> func, int x, int y)
        {
            int result = 0;

            try
            {
                result = func(x, y);
            }
            catch (Exception ex)
            {
                calculatorHandler?.Invoke($"some error: {ex.Message}");
            }

            return result;
        }
    }
}

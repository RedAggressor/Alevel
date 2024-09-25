namespace HomeWork14
{
    public delegate void CalculatorHandler(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            calculator.calculatorHandler += SendFirst.Send;

            calculator.calculatorHandler += SendSecond.Send;

            calculator.Caculate(10, 5);

        }
    }
}

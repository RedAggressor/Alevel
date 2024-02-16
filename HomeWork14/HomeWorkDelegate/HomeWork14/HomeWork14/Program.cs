namespace HomeWork14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateSum calculator = new CalculateSum();

            calculator.calculatorHandler += SendFirst.Send;

            calculator.calculatorHandler += SendSecond.Send;

            calculator.Caculate(10, 5);

        }
    }
}

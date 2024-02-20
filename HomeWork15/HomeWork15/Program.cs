namespace HomeWork15
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var task = Task.Run(() => AsyncReader.ConcatinationHelloWordAsync());

            Console.WriteLine(task.Result);
        }
    }
}

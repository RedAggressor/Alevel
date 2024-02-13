namespace HomeWork11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };

            MyOwnCollection<int> myOwnCollection = new MyOwnCollection<int> (arr);
            
            myOwnCollection.Add(4);
            myOwnCollection.Add(5);
            myOwnCollection.Add(6);

            foreach (var item in myOwnCollection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(myOwnCollection.Count);
            myOwnCollection.SetDefaultAt(1);

            foreach (var item in myOwnCollection)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(myOwnCollection.Count);

            myOwnCollection.Sort(1,3);

            foreach (var item in myOwnCollection)
            {
                Console.WriteLine(item);
            }

            myOwnCollection.Sort(jumperSort:1);

            Console.WriteLine();

            foreach (var item in myOwnCollection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(myOwnCollection.Count);

            myOwnCollection.Sort();

            foreach (var item in myOwnCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}

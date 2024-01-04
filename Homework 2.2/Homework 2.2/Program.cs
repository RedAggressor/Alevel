using RandomElement;

namespace Homework_2._2
{
    internal class Program
    {
         static void Main(string[] args)
         {

            int[] A = new int[20];
            int[] B = new int[20];
            A.SetRandomElement();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= 888)
                {
                    B[i] = A[i];
                }
            }

            for (int i = 0; i < B.Length-1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (B[j - 1] < B[j])
                    {
                        int res = B[j];
                        B[j] = B[j - 1];
                        B[j - 1] = res;
                    }
                }
            }
            Console.WriteLine("Array B after sort is decending order:");
            foreach (var item in B)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
         }
    }
}

using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            for (int row = 1; row <= n; row++)
            {

                for (int col = row; col <= n; col++)
                {
                    if (row >= n - col)
                    {
                        Console.Write("#");
                        Console.Write("\n");

                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.ReadKey();
        }
    }

}
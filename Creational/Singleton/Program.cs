using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NaiveSingleton naiveSingleton1 = NaiveSingleton.GetInstance();
            NaiveSingleton naiveSingleton2 = NaiveSingleton.GetInstance();

            if (naiveSingleton1.Equals(naiveSingleton2))
            {
                Console.WriteLine("Singleton implementation done.");
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            NaiveSingletonClient();
            ThreadSafeSingletonClient();
            Console.ReadKey();
        }

        private static void ThreadSafeSingletonClient()
        {
            Console.WriteLine("Hello, This is thread safe singleton client!");

            Console.WriteLine(
               "{0}\n{1}\n\n{2}\n",
               "If you see the same value, then singleton was reused (yay!)",
               "If you see different values, then 2 singletons were created (booo!!)",
               "RESULT:"
            );

            Thread thread1 = new Thread(() =>
            {
                var singleton = ThreadSafeSingleton.GetInstance("yay!");
                Console.WriteLine(singleton.value);
            });

            Thread thread2 = new Thread(() =>
            {
                var singleton = ThreadSafeSingleton.GetInstance("booo!!");
                Console.WriteLine(singleton.value);
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        private static void NaiveSingletonClient()
        {
            Console.WriteLine("Hello, This is Naive Singleton Client!");

            NaiveSingleton naiveSingleton1 = NaiveSingleton.GetInstance();
            NaiveSingleton naiveSingleton2 = NaiveSingleton.GetInstance();

            if (naiveSingleton1.Equals(naiveSingleton2))
            {
                Console.WriteLine("Singleton implementation done.");
            }
        }
    }
}

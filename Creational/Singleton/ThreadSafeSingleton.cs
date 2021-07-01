using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    // This Singleton implementation is called "double check lock". It is safe
    // in multithreaded environment and provides lazy initialization for the
    // Singleton object
    public class ThreadSafeSingleton
    {
        private ThreadSafeSingleton() { }

        // Some value for demonstration purpose.
        public string value { get; set; }

        private static ThreadSafeSingleton _instance;
        private static readonly object _lock = new object();

        public static ThreadSafeSingleton GetInstance(string value)
        {
            //  This conditional is needed to prevent threads stumbling over the
            // lock once the instance is ready.
            if (_instance is null)
            {
                // Now, imagine that the program has just been launched. Since
                // there's no Singleton instance yet, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (_lock)
                {
                    // The first thread to acquire the lock, reaches this
                    // conditional, goes inside and creates the Singleton
                    // instance. Once it leaves the lock block, a thread that
                    // might have been waiting for the lock release may then
                    // enter this section. But since the Singleton field is
                    // already initialized, the thread won't create a new
                    // object.
                    if (_instance is null)
                    {
                        _instance = new ThreadSafeSingleton();
                        _instance.value = value;
                    }
                }
            }
            return _instance;
        }
    }
}

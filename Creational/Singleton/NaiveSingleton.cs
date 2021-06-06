using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    /// <summary>
    /// Naive implementation of Singleton pattern.
    /// Simplest implementation of singleton pattern but does not really work well in multithreaded program.
    /// </summary>
    class NaiveSingleton
    {
        // Rule 1: Make constructor private.
        private NaiveSingleton() { }

        // Note: Not recommended for multi-threaded program.
        private static NaiveSingleton _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static NaiveSingleton GetInstance()
        {
            if (_instance is null)
            {
                _instance = new NaiveSingleton();
            }
            return _instance;
        }
    }
}

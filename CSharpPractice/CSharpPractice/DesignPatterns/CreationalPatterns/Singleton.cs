using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPractice.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace CSharpPractice.DesignPatterns.CreationalPatterns.Singleton
{
    class Singleton {

        private static Singleton _instance = null;

        private Singleton() { }
        public static Singleton getInstance() {
            
            if (_instance is null)
            {
                _instance = new();
            }

            return _instance;
        }

        public void SomeAction() {

            Console.WriteLine("Some Action ");
        }
    }

    class ThreadSafeSingleton
    {
        private static object _lock = new();

        private static ThreadSafeSingleton _instance = null;

        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton getInstance()
        {
            lock (_lock)
            {
                if (_instance is null)
                {
                    _instance = new();
                    return _instance;
                }

                return _instance;
            }
        }
    }

    class SingletonClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Singleton Test:::");

            Console.WriteLine(Singleton.getInstance().GetHashCode());
            Console.WriteLine(Singleton.getInstance().GetHashCode());

            List<Task<int>> aListOfTasks = new();

            foreach (int i in Enumerable.Range(1, 20))
            {
                aListOfTasks.Add(new Task<int>(() =>
                {
                    return ThreadSafeSingleton.getInstance().GetHashCode();
                }));
            }

            aListOfTasks.ForEach(task => task.Start());

            Task.WaitAll(aListOfTasks.ToArray());

            foreach(var task in aListOfTasks)
            {
                Console.WriteLine("HashCode: " + task.Result);
            }

            Console.WriteLine();
        }
    }
}

using CSharpPractice.DesignPatterns.CreationalPatterns.FactoryMethod;
using CSharpPractice.DesignPatterns.CreationalPatterns.AbstractFactory;

namespace CSharpPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactoryMethodClient.Test();
            AbstractFactoryClient.Test();


            Console.ReadKey();
        }
    }
}

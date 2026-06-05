using CSharpPractice.DesignPatterns.CreationalPatterns.FactoryMethod;
using CSharpPractice.DesignPatterns.CreationalPatterns.AbstractFactory;
using CSharpPractice.DesignPatterns.CreationalPatterns.Builder;
using CSharpPractice.DesignPatterns.CreationalPatterns.Prototype;

namespace CSharpPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactoryMethodClient.Test();
            AbstractFactoryClient.Test();
            BuilderClient.Test();
            PrototypeClient.Test();

            Console.ReadKey();
        }
    }
}

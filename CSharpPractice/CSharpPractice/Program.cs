using CSharpPractice.DesignPatterns.CreationalPatterns.FactoryMethod;
using CSharpPractice.DesignPatterns.CreationalPatterns.AbstractFactory;
using CSharpPractice.DesignPatterns.CreationalPatterns.Builder;
using CSharpPractice.DesignPatterns.CreationalPatterns.Prototype;
using CSharpPractice.DesignPatterns.CreationalPatterns.Singleton;
using CSharpPractice.DesignPatterns.StructuralPatterns.Adapter;
using CSharpPractice.DesignPatterns.StructuralPatterns.Bridge;

namespace CSharpPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            FactoryMethodClient.Test();
            AbstractFactoryClient.Test();
            BuilderClient.Test();
            PrototypeClient.Test();
            SingletonClient.Test();
            AdapterClient.Test();
            BridgeClient.Test();

            Console.ReadKey();
        }
    }
}

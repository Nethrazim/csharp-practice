using CSharpPractice.DesignPatterns.CreationalPatterns.FactoryMethod;
using CSharpPractice.DesignPatterns.CreationalPatterns.AbstractFactory;
using CSharpPractice.DesignPatterns.CreationalPatterns.Builder;
using CSharpPractice.DesignPatterns.CreationalPatterns.Prototype;
using CSharpPractice.DesignPatterns.CreationalPatterns.Singleton;
using CSharpPractice.DesignPatterns.StructuralPatterns.Adapter;
using CSharpPractice.DesignPatterns.StructuralPatterns.Bridge;
using CSharpPractice.DesignPatterns.StructuralPatterns.Composite;
using CSharpPractice.DesignPatterns.StructuralPatterns.Decorator;
using CSharpPractice.DesignPatterns.StructuralPatterns.Facade;
using CSharpPractice.DesignPatterns.StructuralPatterns.Flyweight;
using CSharpPractice.DesignPatterns.StructuralPatterns.Proxy;
using CSharpPractice.DesignPatterns.BehavioralPatterns.ChainOfResponsability;
using CSharpPractice.DesignPatterns.BehavioralPatterns.Template;
using CSharpPractice.GarbageCollector;

using static CSharpPractice.GarbageCollector.GarbageCollectorClient;
using CSharpPractice.DesignPatterns.BehavioralPatterns.Command;


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
            CompositeClient.Test();
            DecoratorClient.Test();
            FacadeClient.Test();
            FlyweightClient.Test();
            ProxyClient.Test();
            ChainOfResponsabilityClient.Test();
            TemplateClient.Test();
            CommandPatternClient.Test();


            GarbageCollectorClient.Test();
            UnmanagedResourceHolder.TestDisposePattern();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.ReadKey();
        }
    }
}

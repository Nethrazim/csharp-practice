using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns.CreationalPatterns.FactoryMethod
{
    public interface IProduct
    {
        string Operation();    
    }

    class ConcreteProduct1 : IProduct {
        public string Operation() {
            return $"{GetType().Name} Operation()";
        }
    }

    class ConcreteProduct2 : IProduct {
        public string Operation()
        {
            return $"{GetType().Name} Operation()";
        }
    }

    abstract class ProductCreator {
        public abstract IProduct FactoryMethod();

        public void SomeOperation()
        {
            var product = FactoryMethod();
            var result = product.Operation();
            Console.WriteLine($"SomeOperation: {result}");
        }
    }

    class ConcreteProductCreator1 : ProductCreator {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteProductCreator2 : ProductCreator {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    class FactoryMethodClient {
        public static void Test()
        {
            Console.WriteLine(":::Factory Method Test:::");
            var client = new FactoryMethodClient();
            
            client.ClientCode(new ConcreteProductCreator1());
            client.ClientCode(new ConcreteProductCreator2());

            Console.WriteLine();
        }

        public void ClientCode(ProductCreator creator) {
            creator.SomeOperation();
        }
    }
}

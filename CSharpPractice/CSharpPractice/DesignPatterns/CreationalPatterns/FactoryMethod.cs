using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns.CreationalPatterns
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
        public static void test()
        {
            new FactoryMethodClient().Main();
        }
        public void Main() { 
            Console.WriteLine("Concrete Product Creator 1");
            ClientCode(new ConcreteProductCreator1());

            Console.WriteLine("Concrete Product Creator 2");
            ClientCode(new ConcreteProductCreator2());
        }

        public void ClientCode(ProductCreator creator)
        {
            creator.SomeOperation();
        }
    }
}

namespace CSharpPractice.DesignPatterns.CreationalPatterns.AbstractFactory
{
    public interface IAbstractFactory {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public interface IAbstractProductA {
        string UsefulFunctionA();
    }

    class ProductA1 : IAbstractProductA {
        public string UsefulFunctionA() {
            return $"{this.GetType().Name} UsefulFunctionA()";
        }
    }

    class ProductA2 : IAbstractProductA {
        public string UsefulFunctionA() {
            return $"{this.GetType().Name} UsefulFunctionA()";
        }
    }

    public interface IAbstractProductB {
        string UsefulFunctionB();
    }

    class ProductB1 : IAbstractProductB {
        public string UsefulFunctionB()
        {
            return $"{this.GetType().Name} UsefulFunctionB()";
        }
    }

    class ProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return $"{this.GetType().Name} UsefulFunctionB()";
        }
    }

    class ConcreteFactory1 : IAbstractFactory {
        public IAbstractProductA CreateProductA() {
            return new ProductA1();
        }

        public IAbstractProductB CreateProductB() {
            return new ProductB1();
        }
    }

    class ConcreteFactory2: IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    class AbstractFactoryClient {

        public static void Test() {
            Console.WriteLine(":::Abstract Factory Test:::");
            
            var client = new AbstractFactoryClient();
            client.ClientCode(new ConcreteFactory1());
            client.ClientCode(new ConcreteFactory2());

            Console.WriteLine();
        }

        public void ClientCode(IAbstractFactory factory) {
            IAbstractProductA productA = factory.CreateProductA();
            IAbstractProductB productB = factory.CreateProductB();

            Console.WriteLine($"{productA.GetType().Name} operation {productA.UsefulFunctionA()} works fine with {productB.GetType().Name}'s operator{productB.UsefulFunctionB()}");
        }
    }
}

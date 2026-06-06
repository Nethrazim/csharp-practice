namespace CSharpPractice.DesignPatterns.StructuralPatterns.Decorator
{
    public interface ICoffee
    {
        public string GetDescription();
        public double GetCost();
    }

    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 2.0;
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        private ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee) => _coffee = coffee;
        
        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return _coffee.GetCost();
        }
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return base.GetDescription() + "Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.0f;
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return base.GetDescription() + "Sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 2.5;
        }
    }


    class DecoratorClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Simple Coffee:::");

            ICoffee coffee = new SimpleCoffee();
            coffee = new MilkDecorator(coffee);
            coffee = new SugarDecorator(coffee);

            Console.WriteLine($"Order: {coffee.GetDescription()}");
            Console.WriteLine($"Cost: ${coffee.GetCost()}");

            Console.WriteLine();
        }
    }
}

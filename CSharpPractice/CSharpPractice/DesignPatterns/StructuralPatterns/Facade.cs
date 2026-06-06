namespace CSharpPractice.DesignPatterns.StructuralPatterns.Facade
{
    public class Subsystem1
    {
        public void Operation1()
        {
            Console.WriteLine("Subsystem1: Ready!");
        }
    }

    public class Subsystem2
    {
        public void Operation2()
        {
            Console.WriteLine("Subsystem2: Ready!");
        }
    }

    public class Facade
    {
        protected Subsystem1 subsystem1;
        protected Subsystem2 subsystem2;
        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2) {
            this.subsystem1 = subsystem1;
            this.subsystem2 = subsystem2;
        }

        public void OperationOffered()
        {
            Console.WriteLine("Facade Operation");

            subsystem1.Operation1();
            subsystem2.Operation2();
        }
    }

    public class FacadeClient {
        public static void Test() {
            Console.WriteLine(":::Facade Test:::");

            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();

            Facade facade = new(subsystem1, subsystem2);

            facade.OperationOffered();

            Console.WriteLine();
        }
    }
}

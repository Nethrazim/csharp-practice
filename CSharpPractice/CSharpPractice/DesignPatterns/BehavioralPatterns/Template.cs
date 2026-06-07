namespace CSharpPractice.DesignPatterns.BehavioralPatterns.Template
{
    public abstract class AbstractTemplate
    {
        public void TemplateMethod()
        {
            BaseOperation1();
            RequiredOperation1();
            BaseOperation2();
            RequiredOperation2();
        }

        protected void BaseOperation1()
        {
            Console.WriteLine("BaseOperation1()");
        }

        protected abstract void RequiredOperation1();

        protected void BaseOperation2()
        {
            Console.WriteLine("BaseOperation2()");
        }

        protected abstract void RequiredOperation2();
    }

    class ConcreteTemplate : AbstractTemplate
    {
        protected override void RequiredOperation1()
        {
            Console.WriteLine("ConcreteTemplate:: RequiredOperation1()");
        }

        protected override void RequiredOperation2()
        {
            Console.WriteLine("ConcreteTemplate:: RequiredOperation2()");
        }
    }

    class TemplateClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Template Pattern Test:::");

            AbstractTemplate template = new ConcreteTemplate();
            template.TemplateMethod();

            Console.WriteLine();
        }
    }
}

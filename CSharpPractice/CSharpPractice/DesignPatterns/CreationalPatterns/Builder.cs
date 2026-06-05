namespace CSharpPractice.DesignPatterns.CreationalPatterns.Builder
{
    public class Product {
       private List<object> _parts = new();

        public void Add(string part) {
            this._parts.Add(part);    
        }

        public string ListParts() {
            return string.Join(",", _parts);
        }   
    }


    public interface IBuilder {
        void Reset();
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();
    }

    public class ConcreteBuilder : IBuilder {
        private Product _product = new();

        public ConcreteBuilder() {
            Reset();     
        }

        public void BuildPartA() {
            _product.Add("Part A");
        }

        public void BuildPartB() {
            _product.Add("Part B");
        }

        public void BuildPartC() {
            _product.Add("Part C");
        }

        public void Reset() {
            this._product = new Product();
        }

        public Product ReturnProduct() {
            Product product = _product;
            Reset();
            return product;
        }
    }

    class Director
    {
        public required IBuilder Builder { private get; set; }

        public void BuildMinimumViableProduct() {
            Builder.Reset();
            Builder.BuildPartA();
        }

        public void BuildFullFeaturedProduct() {
            Builder.Reset();
            Builder.BuildPartA();
            Builder.BuildPartB();
            Builder.BuildPartC();
        }
    }

    class BuilderClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Builder Test:::");
            var client = new BuilderClient();

            var builder = new ConcreteBuilder();

            Director director = new Director() { 
                Builder = builder 
            };

            director.BuildMinimumViableProduct();
            Console.WriteLine(builder.ReturnProduct().ListParts());

            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.ReturnProduct().ListParts());

            Console.WriteLine();
        }

    }
}

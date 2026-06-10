namespace CSharpPractice.DesignPatterns.BehavioralPatterns.Visitor
{
    public interface IModelVisitor
    {
        void Visit(Order order);
        void Visit(Customer customer);
    }

    public interface IVisitableModel
    {
        void Accept(IModelVisitor visitor);
    }

    public class Order : IVisitableModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public void Accept(IModelVisitor visitor) => visitor.Visit(this);
    }
    public class Customer : IVisitableModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public void Accept(IModelVisitor visitor) => visitor.Visit(this);
    }

    public class HtmlExportVisitor : IModelVisitor
    {
        public string Result { get; private set; } = "";
        public void Visit(Order order)
        {
            Result += $"<div>Order #{order.Id}: Amount = {order.Amount:C}</div>\n";
        }

        public void Visit(Customer customer)
        {
            Result += $"<div>Customer #{customer.Id}: Name = {customer.Name}</div>\n";
        }
    }

    public class VisitorPatternClient
    {
        public static void Test()
        {
            var models = new List<IVisitableModel>
            {
                new Order { Id = 1, Amount = 99.99m },
                new Customer { Id = 2, Name = "Alice" },
                new Order { Id = 3, Amount = 149.50m }
            };

            var htmlVisitor = new HtmlExportVisitor();

            foreach (var model in models)
            {
                model.Accept(htmlVisitor);
            }

            Console.WriteLine(htmlVisitor.Result);
        }
    }

}

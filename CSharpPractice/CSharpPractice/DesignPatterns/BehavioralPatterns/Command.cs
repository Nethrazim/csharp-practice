namespace CSharpPractice.DesignPatterns.BehavioralPatterns.Command;
public enum ProductType
{
    Cizma,
    Borcan
}
public interface IOrderCommand
{
    ProductType ProductType { get; set; }
    int Quantity { get; set; }
}
public class CreateOrderCommand: IOrderCommand
{
    public CreateOrderCommand(ProductType productType, int quantity)
    {
        ProductType = productType;
        Quantity = quantity;
    }

    public ProductType ProductType { get; set; }
    public int Quantity { get; set; }
}

public interface ICommandHandler<TCommand>
        where TCommand : class
{
    public Task Handle(TCommand command);
}

public class CreateOrderHandler
    : ICommandHandler<CreateOrderCommand>
{
    private readonly CreateOrderService _createOrderService;

    public CreateOrderHandler(CreateOrderService service)
    {
        _createOrderService = service;
    }

    public async Task Handle(CreateOrderCommand command)
    {
        await _createOrderService.CreateOrderAsync(command);
    }
}
public interface ICreateOrderService
{
    Task CreateOrderAsync(CreateOrderCommand command);
}
public class CreateOrderService: ICreateOrderService
{
    public Task CreateOrderAsync(CreateOrderCommand command)
    {
        return Task.CompletedTask;
    }
}

public class Invoker
{
    public void Execute<TCommand>(ICommandHandler<TCommand> handler, TCommand command)
        where TCommand : class
    {
        handler.Handle(command);
    }
}


public class CommandPatternClient
{
    public static void Test()
    {   
        var orderService = new CreateOrderService();
        var handler = new CreateOrderHandler(orderService);

        var command = new CreateOrderCommand(ProductType.Borcan, 2);
        var invoker = new Invoker();
        invoker.Execute(handler, command);
    }
}
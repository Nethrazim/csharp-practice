using System.Data.SqlTypes;

namespace CSharpPractice.DesignPatterns.BehavioralPatterns.ChainOfResponsability;
public interface IHandler
{
    IHandler SetNext(IHandler handler);
    object Handle(object request);
}

abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        this._nextHandler = handler;
        return handler;
    }

    public virtual object Handle(object request)
    {
        if (this._nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        return null;
    }
}

class MonkeyHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "Nut")
        {
            return $"Squirrel: I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}

class DogHandler : AbstractHandler
{
    public override object Handle(object request)
    {
        if (request.ToString() == "MeatBall")
        {
            return $"Dog: I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Handle(request);
        }
    }
}
class ChainOfResponsabilityClient
{
    public static void Test()
    {
        Console.WriteLine(":::ChainOfResponsability Test:::");

        var monkey = new MonkeyHandler();
        var dog = new DogHandler();

        monkey.SetNext(dog);


        foreach(var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
        {
            Console.WriteLine($"Client: Who wants a {food}?");
            Console.WriteLine($"{monkey.Handle(food)}");
        }

        Console.WriteLine();
    }
}

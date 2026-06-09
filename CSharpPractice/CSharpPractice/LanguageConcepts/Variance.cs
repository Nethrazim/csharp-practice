namespace CSharpPractice.LanguageConcepts.Variance;

public interface ICovariant<out T>
{
    T GetItem();
}

public class CovariantExample<T> : ICovariant<T>
{
    private readonly T _item;
    public CovariantExample(T item)
    {
        _item = item;
    }

    public T GetItem()
    {
        return _item;
    }
}

public interface IContravariant<in T>
{
    void SetItem(T item);
}

public class ContravariantExample<T> : IContravariant<T>
{
    public void SetItem(T item)
    {
        Console.WriteLine($"Item set: {item}");
    }
}
public class Animal
{
    public virtual string Speak() => "I'm an animal.";
}

public class Dog : Animal {
    public override string Speak() => "Woof! I am a dog.";
}

public delegate Animal CovariantDelegate();
public delegate void ContravariantDelegate(Animal dog);


class Variance
{
    public static void TestVariance()
    {
        ICovariant<Animal> covariantAnimal = new CovariantExample<Dog>(new Dog());
        Console.WriteLine(covariantAnimal.GetItem().Speak());

        IContravariant<Dog> contravariantDog = new ContravariantExample<Animal>();
        contravariantDog.SetItem(new Dog());

        CovariantDelegate covariantDelegate = () => new Dog();
        Animal animal = covariantDelegate();
        Console.WriteLine(animal.Speak());

        ContravariantDelegate contravariantDelegate = (Animal a) =>
        {
            Console.WriteLine(a.Speak());
        };
        contravariantDelegate(new Dog());
    }
}

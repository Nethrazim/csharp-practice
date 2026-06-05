namespace CSharpPractice.DesignPatterns.CreationalPatterns.Prototype
{
    public interface IShallowClone<T>
        where T : class
    {
        public T ShallowClone();
    }


    public interface IDeepClone<T>
        where T: class
    {
        public T DeepClone();
    }

    public class Person : IDeepClone<Person>, IShallowClone<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public Person DeepClone()
        {
            Person deepClone = new()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Age = this.Age,
                Address = new()
                {
                    Address1 = this.Address?.Address1,
                    Address2 = this.Address?.Address2,
                    Country =  this.Address?.Country
                }
            };

            return deepClone;
        }

        public Person ShallowClone()
        {
            Person shalowClone = new() {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Age = this.Age
            };

            return shalowClone;
        }
    }

    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
    }

    class PrototypeClient
    {
        public delegate Person cloneDelegate();

        public static void Test()
        {
            Console.WriteLine(":::Prototype Test:::");
            var client = new PrototypeClient();
            var person = new Person()
            {
                FirstName = "Vlad",
                LastName = "Banzo",
                Age = 30,
                Address = new Address()
                {
                    Address1 = "address1",
                    Address2 = "address2",
                    Country = "Romania"
                }
            };

            cloneDelegate deepClone = new cloneDelegate(person.DeepClone);
            cloneDelegate shallowDelegate = new(person.ShallowClone);

            client.ClientCode(shallowDelegate);
            client.ClientCode(deepClone);
 
            Console.WriteLine();
        }

        public void ClientCode(cloneDelegate cloneDelegate)
        {
            Person clone = cloneDelegate();
            
            if (clone.Address is null)
            {
                Console.WriteLine("Is Shallow Clone");
            }
            else
            {
                Console.WriteLine("Is Deep Clone");
            }

            Console.WriteLine(clone.FirstName);
            Console.WriteLine(clone.Address?.Country ?? "");
        }
    }

}

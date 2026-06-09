using System.Collections;
using IEnumerator = System.Collections.IEnumerator;

namespace CSharpPractice.DesignPatterns.BehavioralPatterns.Iterator
{
    public class ReverseList<T> : IEnumerable<T>
    {
        private readonly List<T> _innerList = new();
        public ReverseList(IEnumerable<T> enumerable) {
            foreach (var item in enumerable)
            {
                _innerList.Add(item);
            }
        }

        public List<T> GetCollection() { return _innerList; }
        public IEnumerator<T> GetEnumerator()
        {
            return new ReverseListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ReverseListEnumerator<T> : IEnumerator<T>
    {
        private readonly ReverseList<T> _reverseList;

        private int position = -1;
        public ReverseListEnumerator(ReverseList<T> reverseList)
        {
            _reverseList = reverseList;
            position = reverseList.GetCollection().Count - 1;
        }

        public T Current
        {
            get
            {
                if (position < 0 || position >= _reverseList.GetCollection().Count)
                {
                    throw new InvalidOperationException();
                }

                return _reverseList.GetCollection()[position];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // No resources to release in this implementation
        }

        public bool MoveNext()
        {
            position--;
            return position >= 0;
        }

        public void Reset()
        {
            position = _reverseList.GetCollection().Count - 1;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class IteratorClient { 
        public static void Test() {
            ReverseList<Person> persons = new ReverseList<Person>(
                new List<Person>()
                {
                    new Person() { FirstName = "asd", LastName = "tst" },
                    new Person() { FirstName = "dsd", LastName = "dst" }
                });

            foreach (var item in persons)
            {
                Console.WriteLine($"item {item.FirstName} {item.LastName}");
            }
        }
    }
}

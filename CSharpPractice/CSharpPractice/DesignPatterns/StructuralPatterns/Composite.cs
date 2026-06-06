/*
 * Composite is a structural design pattern that lets you compose objects 
 * into tree structures and then work with these structures 
 * as if they were individual objects.
 */
namespace CSharpPractice.DesignPatterns.StructuralPatterns.Composite
{
    //Component
    public abstract class FileSystemItem
    {
        public string Name { get; }
        protected FileSystemItem(string name) => Name = name;

        public abstract void Display(int depth = 0);
    }

    //Leaf
    public class File : FileSystemItem
    {
        public File(string name) : base(name) { }

        public override void Display(int depth = 0)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }
    }

    //Composite
    public class Directory : FileSystemItem
    {
        private readonly List<FileSystemItem> _children = new();

        public Directory(string name) : base(name) { }

        public void Add(FileSystemItem item) => _children.Add(item);

        public override void Display(int depth = 0)
        {
            Console.WriteLine(new string('-', depth) + Name);

            foreach (var child in _children)
            {
                child.Display(depth + 2);
            }
        }
    }

    class CompositeClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Composite Pattern Test:::");
            var root = new Directory("root");
            root.Add(new File("file1.txt"));
            root.Add(new File("file2.txt"));

            var subDir = new Directory("subdir");
            subDir.Add(new File("file3.txt"));

            root.Add(subDir);

            root.Display();

            Console.WriteLine();
        }
    }
}

using System.Runtime;

namespace CSharpPractice.GarbageCollector;

public class GarbageCollectorClient
{
    public static void Test()
    {
        DisplayGCInfo();
        GenerationalGCExample();
        PinnedObjectHeapExample();
        LargeObjectHeapExample();
        ForceGarbageCollection();
    }

    private static void DisplayGCInfo()
    {
        Console.WriteLine("\n--- GC Information ---");
        Console.WriteLine($"Is Server GC: {GCSettings.IsServerGC}");
        Console.WriteLine($"Latency Mode: {GCSettings.LatencyMode}");
        Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)} byes");
        Console.WriteLine($"Max Generation: {GC.MaxGeneration}");
    }

    private static void GenerationalGCExample()
    {
        Console.WriteLine("\n--- Generational GC Example ---");

        var obj = new object();
        Console.WriteLine($"Generation of obj: {GC.GetGeneration(obj)}");

        GC.Collect();
        Console.WriteLine($"Generation of obj after GC: {GC.GetGeneration(obj)}");
    }

    private static void PinnedObjectHeapExample()
    {
        Console.WriteLine("\n--- Pinned Object Heap (POH) Example---");

        byte[] pinnedArray = GC.AllocateArray<byte>(1024, pinned: true);
        Console.WriteLine($"Pinned object created. Length: {pinnedArray.Length}");
        Console.WriteLine($"Generation of pinnedArray: {GC.GetGeneration(pinnedArray)}");
    }

    private static void LargeObjectHeapExample() {
        Console.WriteLine("\n--- Large Object Heap (LOH) Example ---");

        byte[] largeObject = new byte[100_000];
        Console.WriteLine($"Large object allocated. Length: {largeObject.Length}");

        //LOH object are in Gen2
        Console.WriteLine($"Generation of largeObject: {GC.GetGeneration(largeObject)}");
    }

    private static void ForceGarbageCollection()
    {
        Console.WriteLine("\n--- Forcing Garbage Collection ---");

        for (int i = 0; i < 10; i++)
        {
            _ = new object();
        }

        Console.WriteLine("Forcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Garbage collection completed");
    }
}

public class UnmanagedResourceHolder : IDisposable
{
    private FileStream? _fileStream;
    private bool _disposed = false;

    public UnmanagedResourceHolder(string filePath)
    {
        _fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
    }

    ~UnmanagedResourceHolder()
    {
        Console.WriteLine("Finalizer of UnmanagedResourceHolder()");
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        //GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _fileStream?.Dispose();
            }
            _disposed = true;
        }
    }
    public static void TestDisposePattern()
    {
        using (var holder = new UnmanagedResourceHolder("test.txt"))
        {

        }
    }
}

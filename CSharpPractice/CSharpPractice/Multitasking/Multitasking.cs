using System.Threading.Tasks;

namespace CSharpPractice.Multitasking;
class Multitasking
{
    public static void TaskExceptionHandling()
    {
        var task = Task.Run(() =>
        {
            throw new InvalidOperationException("Something went wrong");
        });

        try
        {
            task.Wait();
        }
        catch (AggregateException ex)
        {
            foreach (var inner in ex.InnerExceptions)
            {
                Console.WriteLine($"Caught exception: {inner.Message}");
            }
        }
    }

    public static void WaitAllAndWaitAny()
    {
        var tasks = new[]
        {
            Task.Delay(1000),
            Task.Delay(2000),
            Task.Delay(1500)
        };

        Console.WriteLine("Waiting for all tasks to complete...");
        Task.WaitAll(tasks);
        Console.WriteLine("All tasks completed");

        var tasks2 = new[]
        {
            Task.Delay(1000),
            Task.Delay(2000),
            Task.Delay(1500)
        };

        Console.WriteLine("Waiting for any task to complete...");

        int index = Task.WaitAny(tasks2);

        Console.WriteLine($"Task {index} completed first.");
    }

    public static void TaskCancellation()
    {
        var cts = new CancellationTokenSource();

        var token = cts.Token;

        var task = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine($"Working...{i}");
                Thread.Sleep(200);
            }
        }, token);

        Thread.Sleep(500);
        cts.Cancel();

        try
        {
            task.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"Task cancelled: {ex.InnerException?.Message}");
        }
    }

    public static void TaskContinuation()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Initial task running.");
            return 42;
        });

        var continuation = task.ContinueWith(t =>
        {
            Console.WriteLine($"Continuation received result");
        });

        continuation.Wait();
    }

    public static void ParallelForExamples()
    {
        Console.WriteLine("Parallel.For:");

        Parallel.For(0, 5, i =>
        {
            Console.WriteLine($"Parallel.For iteration {i} {Thread.CurrentThread}");
        });

        Console.WriteLine("Parallel.ForEach:");
        var items = Enumerable.Range(1, 5);
        Parallel.ForEach(items, item =>
        {
            Console.WriteLine($"Parallel.ForEach item {item} on thread {Thread.CurrentThread}");
        });
    }

    public static async Task AsyncAwaitExceptionHandling()
    {
        try
        {
            await Task.Run(() =>
            {
                throw new ApplicationException("Exception in async task!");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught async exception: {ex.Message}");
        }
    }

    public static async Task DeadlockExample()
    {
        // This will deadlock if called from a UI thread or a context that waits synchronously
        // Console.WriteLine("Deadlock example starting...");
        // var task = Task.Run(async () => { await Task.Delay(1000); });
        // task.Wait(); // Deadlock if called from a context with a synchronization context (e.g., WinForms/WPF)
        // Console.WriteLine("Deadlock example finished.");

        await Task.Run(async () => { await Task.Delay(1000); });
    }

    public static async Task WhenAllWhenAnyExample()
    {
        var t1 = Task.Delay(1000);
        var t2 = Task.Delay(2000);
        var t3 = Task.Delay(1500);

        await Task.WhenAll(t1, t2, t3);
        Console.WriteLine("All tasks finished (WhenAll).");

        var first = await Task.WhenAny(t1, t2, t3);
        Console.WriteLine("First task finished (WhenAny).");

    }
}

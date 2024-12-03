using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Method1()
    {
        Console.WriteLine($"Method1 started in the stream: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000);
        Console.WriteLine("Method1 completed the work.");
    }

    static void Method2()
    {
        Console.WriteLine($"Method2 started in the stream: {Thread.CurrentThread.ManagedThreadId}");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Method2 performs the operation {i + 1}");
            Thread.Sleep(500);
        }
        Console.WriteLine("Method2 completed the work.");
    }

    static void Method3()
    {
        Console.WriteLine($"Method3 started in the stream: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        Console.WriteLine("Method3 completed the work.");
    }

    static async Task AsyncMethod1()
    {
        Console.WriteLine($"AsyncMethod1 started in the stream: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(2000);
        Console.WriteLine("AsyncMethod1 completed the work.");
    }

    static async Task AsyncMethod2()
    {
        Console.WriteLine($"AsyncMethod2 started in the stream: {Thread.CurrentThread.ManagedThreadId}");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"AsyncMethod2 performs the operation {i + 1}");
            await Task.Delay(1000);
        }
        Console.WriteLine("AsyncMethod2 completed the work.");
    }

    static async Task AsyncMethod3()
    {
        Console.WriteLine($"AsyncMethod3 started in the stream: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Run(() =>
        {
            Thread.Sleep(1500);
            Console.WriteLine($"AsyncMethod3 performed calculations in the stream: {Thread.CurrentThread.ManagedThreadId}");
        });
        Console.WriteLine("AsyncMethod3 completed the work.");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Demonstration of work with Thread:");

        Thread thread1 = new Thread(Method1);
        Thread thread2 = new Thread(Method2);
        Thread thread3 = new Thread(Method3);

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("\nDemonstration of work with Async-Await:");
        Task.Run(async () =>
        {
            await AsyncMethod1();
            await AsyncMethod2();
            await AsyncMethod3();
        }).GetAwaiter().GetResult();

        Console.WriteLine("\nAll methods completed.");
        Console.ReadLine();
    }
}


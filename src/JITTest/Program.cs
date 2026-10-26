using System;

namespace JITTest;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("App started");

        var cts = new CancellationTokenSource();

        await Task.Delay(5000, cts.Token);

        Console.WriteLine("Everything is ended.");
    }
}
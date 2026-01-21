
using System;

namespace CSTest;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("running...");

        var cts = new CancellationTokenSource();
        var ct = cts.Token;

        var result = Download(ct);

        Thread.Sleep(3000);

        cts.Cancel();

        var res = await result;
        Console.WriteLine($"downloaded: {res}");

        Console.WriteLine("everything is ended.");
    }

    public static async Task<string> Download(CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("downloading data...");
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            Console.WriteLine("data downloaded successfully.");
            return "data";
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("download operation was canceled!");
            return "canceled";
        }
    }
}
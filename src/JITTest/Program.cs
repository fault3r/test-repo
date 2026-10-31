
using System;

namespace JITTest;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("App started..");

        var cts = new CancellationTokenSource(
            TimeSpan.FromSeconds(5));

        var downloader = new Downloader();

        var result = await downloader.Download("url", cts.Token);

        Console.WriteLine($"Data: {result}");

        Console.WriteLine("Everyhting is ended.");
    }
}

public class Downloader
{
    public async Task<string> Download(string url, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Status: start downloading..");

        try
        {
            await Task.Delay(2000, cancellationToken);      
        }
        catch(Exception e)
        {
            Console.WriteLine($"Status: download failed! {e.Message}");
        }

        return "Downloaded Data.";    
    }
}


using System;
using System.Threading.Tasks;

namespace CSTest;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("App started...\n");

        var task = Task.Run(() => Loading());
        Console.WriteLine("\nresumming...\n");

        Thread.Sleep(5000);
        stop = true;

        await task;

        Console.WriteLine("\nEverything is ended.");
    }

    public static bool stop = false;

    public static Task Loading()
    {
        string text = "Damaavandi";

        int left = Console.CursorLeft + 20;
        int top = Console.CursorTop;

        for (int i = 0; i < text.Length; i++)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(text[i..(i + 1)]);
            Thread.Sleep(300);

            if (i == text.Length-1) i = 0;
            if (stop) break;
        }
        return Task.CompletedTask;
    }
}
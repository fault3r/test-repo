
using System;

namespace CSTest;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("App started...");
        Console.WriteLine($"Main Thread ID: {Environment.CurrentManagedThreadId}");

        var loadingThread = new Thread(Loading);
        

        Console.WriteLine("\nPress any key to exit..");
        var input = Console.ReadKey(intercept: true);

        Console.WriteLine("Everything is ended.");
    }

    public static void Loading()
    {
        Console.WriteLine($"Loading Thread ID: {Environment.CurrentManagedThreadId}");

        int left = Console.CursorLeft + 26;
        int top = Console.CursorTop;

        char[] loading = ['|', '\\', '/'];
        int x = 0;
        while (x < loading.Length)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(loading[x]);
            Console.WriteLine();
            Thread.Sleep(300);
            x++;
            if (x == loading.Length)
                x = 0;
        }
    }
}
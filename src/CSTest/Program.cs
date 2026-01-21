
using System;
using System.Threading.Tasks;

namespace CSTest;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("App started...");

        Task task = Loading();
        
        Console.Write("\nwaiting..");
        Thread.Sleep(5000);
        stop = true;

        await task;

        Console.WriteLine("\nEverything is ended.");
    }

    public static bool stop = false;

    public static async Task Loading()
    {
        string text = "\\|/|";

        int left = Console.CursorLeft + 26;
        int top = Console.CursorTop;

        for (int i = 0; i < text.Length; i++)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(text[i..(i + 1)]);
            await Task.Delay(300);

            if (i == text.Length - 1) i = -1;
            if (stop) break;
        }
    }
}

using System;
using System.Threading.Tasks;

namespace CSTest;

internal class Program
{
    public async Task Main(string[] args)
    {
        Console.WriteLine("App started...");

        Task task = Task.Run(() => Loading());
        
        Console.Write("\nwaiting..");
        Thread.Sleep(5000);
        stop = true;

        await task;

        Console.WriteLine("\nEverything is ended.");
    }

    public  bool stop = false;

    public  async Task Loading()
    {
        string text = "\\|/|";

        int left = Console.CursorLeft + 26;
        int top = Console.CursorTop;

        for (int i = 0; i < text.Length; i++)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(text[i..(i + 1)]);
            Thread.Sleep(300);

            if (i == text.Length - 1) i = -1;
            if (stop) break;
        }
    }
}
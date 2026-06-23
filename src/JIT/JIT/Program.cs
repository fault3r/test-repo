
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JIT
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
             var writer = new ConsoleWriter();
             writer.WriteAsync("Aaaa");

        }
    }

    public sealed class ConsoleWriter
    {
        private const string Characters = "abcdefghijklmnopqrstuvwxyz";
        private Random Randomizer = new();

        private char[] GetDummy(int lenght = 5)
        {
            char[] chars = new char[lenght];

            for(int i=0;i<lenght;i++)
            {
                var random = Randomizer.Next(0,26);
                chars[i]=Characters[random];
            }

            return chars;
        }

        public async Task WriteAsync(string text)
        {
            var res = GetDummy();
            Console.WriteLine(res);
        }
    }
}
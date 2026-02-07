
using System;
using System.Security.Cryptography;

namespace CSTestB;

internal class ProgramB
{
    public static async Task Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(
                RandomStringGenerator.Generate());
        }
    }
}

public static class RandomStringGenerator
{
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private static readonly Random Rnd = new();

    public static string Generate(int length = 8)
    {
        var generated = new char[length];

        for (int i = 0; i < length; i++)
            generated[i] = Chars[Rnd.Next(Chars.Length)];

        return string.Concat(generated);
    }
}

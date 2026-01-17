
using System;
using CSTest;

Console.Write("Proccess started..\n");

Predicate<int> checkodd = (num) => num % 2 != 0;

var tester = new CST();
tester.CheckOdd(checkodd, 5);
tester.CheckOdd(checkodd, 6);
tester.CheckOdd(checkodd, 7);
tester.CheckOdd(checkodd, 8);

Console.Write("Proccess finished.\n");

// ---

namespace CSTest
{
    public class CST
    {
        public void CheckOdd(Predicate<int> pred, int x)
            => Console.WriteLine($"{x} check: {pred(x)}");
    }

}
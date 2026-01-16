
using System;
using CSTest;

Console.Write("Proccess started..\n");

var starter = new ThreadTest();

var t1 = new Thread(starter.TaskOne);
var t2 = new Thread(starter.TaskTwo);
var t3 = new Thread(starter.TaskThree);

t1.Start();
t2.Start();
t3.Start();


Thread.Sleep(TimeSpan.FromSeconds(3));

Console.Write("Proccess finished.\n");

// --- 

namespace CSTest
{
    public class ThreadTest
    {
        public void TaskOne()
        {
            for (int i = 1; i < 50; i++)
                Console.WriteLine($"One: Hey! {i}");
        }

        public void TaskTwo()
        {
            for (int i = 1; i < 50; i++)
                Console.WriteLine($"Two: Hi!{i}");
        }

        public void TaskThree()
        {
            for (int i = 1; i < 50; i++)
                Console.WriteLine($"Three: Hi!{i}");
        }
    }
}
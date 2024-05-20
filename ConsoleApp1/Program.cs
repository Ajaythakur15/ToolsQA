using System;
namespace FunctionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Sum();
            Console.ReadKey();
        }
        static void Sum()
        {
            int x = 10;
            int y = 20;
            int sum = x + y;
            Console.WriteLine($"Sum of {x} and {y} is {sum}");
        }
    }
}
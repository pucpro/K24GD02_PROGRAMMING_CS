using System;

delegate int Operation(int a, int b);

class Program
{
    static void Main()
    {
        Operation sum = delegate (int a, int b) { return a + b; };
        Console.WriteLine("Tong: " + sum(5, 7));
        Console.ReadKey();
    }
}
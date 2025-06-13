using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int a = 10, b = 8;
        List<Action> actions = new List<Action>
        {
            () => Console.WriteLine($"Gia tri ban dau: a = {a}, b = {b}"),
            () => { int temp = a; a = b; b = temp; },
            () => Console.WriteLine($"Sau khi hoan doi: a = {a}, b = {b}")
        };
        foreach (var action in actions)
        {
            action();
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> so = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            so.Add(i);
        }
        so.RemoveAll(n => n % 2 == 0);
        Console.WriteLine("Danh sach con lai: " + string.Join(", ", so));
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Nhap ss luong phan tu (n > 0): ");
        int n = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            numbers.Add(random.Next(100)); 
        }

        Console.WriteLine("\nDay so ngau nhien:");
        Console.WriteLine(string.Join(", ", numbers));
        
        numbers.Sort();
        Console.WriteLine("\nDay so sau khi sap xep tang dan:");
        Console.WriteLine(string.Join(", ", numbers));
        Console.ReadLine();
    }
}
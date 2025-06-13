using System;
using System.Collections.Generic;

class NumberList
{
    public event EventHandler<int> NumberAdded;
    private List<int> numbers = new List<int>();

    public void AddNumber(int num)
    {
        numbers.Add(num);
        NumberAdded?.Invoke(this, num);
    }
}

class Program
{
    static void Main()
    {
        NumberList numList = new NumberList();
        numList.NumberAdded += (sender, num) => Console.WriteLine($"Da them so: {num}");

        numList.AddNumber(6);
        numList.AddNumber(10);
    }
}
using System;
using System.Collections.Generic;

namespace vd2lap3
{
    delegate void MyDelegateDemo01();
    delegate void MyDelegateDemo02(string name);

    internal class Program
    {
        static void Main(string[] args)
        {
            MyDelegateDemo01 myDemo01 = ShowMessage;
            myDemo01?.Invoke(); 

            MyDelegateDemo02 myDelegate02 = delegate (string name)
            {
                Console.WriteLine("Anonymous Hello World " + name);
            };
            myDelegate02?.Invoke("Bob");

            Action<int> myDemo03Int = delegate (int num)
            {
                Console.WriteLine("Anonymous hello world " + num);
            };
            myDemo03Int?.Invoke(10); 

            Action<double, double> myDemo03Double = delegate (double a, double b)
            {
                Console.WriteLine($"Tích {a} x {b} = {a * b}");
            };
            myDemo03Double?.Invoke(10, 5);
            Func<int, int, int> myDemo4 = delegate (int a, int b)
            {
                return a*b;
            };
            Console.WriteLine($"Func Tich: " + myDemo4(10, 5));
            Func <int , int , double> myDemo5 = delegate (int a, int b)
            {
                return a/ b;
            };
            Console.WriteLine($"Func Chia: " + myDemo5(10, 5));

            Func<double, double, double> mydemo4 = delegate(double a , double b)
            {
                double value = 0;
                return value;
            };
            Predicate<int> isEven = x => x % 2 == 0;
            List  <int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evens = numbers.FindAll(isEven);
            var removed = numbers.RemoveAll(x => x < 4);
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                actions.Add(() => Console.WriteLine(i));
            }
            foreach (var action in actions)
            {
                action();
            }


            Console.ReadLine();
        }

        public static void ShowMessage()
        {
            Console.WriteLine("Hello world");
        }

    }
}
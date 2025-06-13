using System;

delegate int PhepTinh(int x); 

class Program
{
    static int Square(int x) => x * x;
    static int Cube(int x) => x * x * x;

    static void Main()
    {
        PhepTinh tinhToan = Square; 
        Console.WriteLine("Ket qua: " + tinhToan(3));
    }
}
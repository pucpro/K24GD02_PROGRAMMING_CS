using System;

delegate double PhepTinh(double a, double b); 

class Program
{
    static double TinhTong(double a, double b) => a + b;
    static double TinhHieu(double a, double b) => a - b;
    static double TinhTich(double a, double b) => a * b;
    static double TinhThuong(double a, double b) =>  a / b ;

    static void Main()
    {
        PhepTinh tong = TinhTong;
        PhepTinh hieu = TinhHieu;
        PhepTinh tich = TinhTich;
        PhepTinh thuong = TinhThuong;

        double a = 10.2, b = 5.3;

        Console.WriteLine($"Tong: {tong(a, b)}");
        Console.WriteLine($"Hieu: {hieu(a, b)}");
        Console.WriteLine($"Tich: {tich(a, b)}");
        Console.WriteLine($"Thuong: {thuong(a, b)}");

        Console.ReadLine(); 
    }
}
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Nhap so nguyen x, y:");
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                double h = Math.Sqrt((3 * x + 2 * y) / (2.0 * x - y));
                Console.WriteLine($"Gia tri của h: {h}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Loi: Vui long nhap so nguyen hop le.");
            }
        }
    }
}
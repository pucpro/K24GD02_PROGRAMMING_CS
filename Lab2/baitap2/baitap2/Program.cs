using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, double> products = new Dictionary<String, double>()
            {
                { "Cam", 1.5 },
                { "Tao", 2.5 },
                { "Le", 3.5 },
                { "Vai", 4.5 }
            };
            Console.WriteLine("Danh sach san pham ban dau");
            PrintProducts(products);
            products["Le"] = 5.5;
            Console.WriteLine("\n sau khi cap nhat gia san pham 'Le': ");
            PrintProducts(products);
            products.Remove("Tao");
            Console.WriteLine("\n sau khi xoa san pham 'Tao'");
            PrintProducts(products);
        }
        static void PrintProducts(Dictionary<String, double> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"san pham: {item.Key}, gia: { item.Value} USD");
            }
        }
    }
}

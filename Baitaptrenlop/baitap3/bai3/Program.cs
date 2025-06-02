using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customerQueue = new Queue<string>();
            customerQueue.Enqueue("khach 1");
            customerQueue.Enqueue("khach 2");
            customerQueue.Enqueue("khach 3");
            customerQueue.Enqueue("khach 4");
            customerQueue.Enqueue("khach 5");
            Console.WriteLine("danh sach ban dau:");
            PrintQueue(customerQueue);

            customerQueue.Dequeue();
            customerQueue.Dequeue();

            Console.WriteLine("\ndanh sach sau khi xoa 2 nguoi khach: ");
            PrintQueue(customerQueue);
        }
        static void PrintQueue(Queue<string> Queue)
        {
            foreach (var customer in Queue)
            {
                Console.WriteLine(customer.ToString());
            }
        }
    }
}

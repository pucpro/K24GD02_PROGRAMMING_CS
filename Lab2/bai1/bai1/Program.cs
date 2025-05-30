using System;
using System.Collections;

namespace bai1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arraylist = new ArrayList();
            arraylist.Add("Item 01");
            arraylist.Add("Item 02");
            arraylist.Add(1);
            arraylist.Add(2);

            Console.WriteLine(arraylist.Count);
            for (int i = 0; i < arraylist.Count; i++) 
            {
                Console.WriteLine(arraylist[i]);
            }
            arraylist.Insert(1, "Item 04");
            ArrayList arrayList2 = new ArrayList();
            arrayList2.Add(5);
            arrayList2.Add("Item 6");   
            arraylist.AddRange(arrayList2);
            
            arraylist.Remove(5);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("Key1", "value1");
            hashtable.Add("Key2", "value2");
            hashtable.Add("Key3", "value3");
            hashtable.Add("Key4", 4);
            hashtable.Add(5, "value5");
            //hashtable.Add("key6", "value6");
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine("key: {0} - value: {1}", item.Key, item.Value);
            }
            foreach (var key  in hashtable.Keys)
            {
                Console.WriteLine("key: {0}", key);
            }
            foreach (var value in hashtable.Keys)
            {
                Console.WriteLine("value: {0}", value);
            }
            hashtable.Remove("Key3");
            Hashtable hashtable2 =(Hashtable) hashtable.Clone();
            hashtable.Clear();
            
            SortedList  sortedList = new SortedList();
            sortedList.Add("First", 1);
            sortedList.Add("key 2", 2);
            sortedList.Add("third", "value 3");
            sortedList.Add("Third", "value 3");
            bool haskey = sortedList.Contains("T");
            bool hasvalue = sortedList.Contains("T");
            SortedList sortedlist2 = (SortedList) sortedList.Clone();
            sortedlist2.Clear();
            Stack stack = new Stack();
            stack.Push("Item01");
            stack.Push("Item02");
            stack.Push("Item03");
            stack.Push("Item04");
            stack.Push("Item05");
            stack.Pop();

            Queue queue = new Queue();
            queue.Enqueue("Item 01");
            queue.Enqueue("Item 02");
            queue.Enqueue("Item 03");
            queue.Enqueue("Item 04");
            queue.Enqueue("Item 05");
            var itemqueue =queue.Dequeue();
            

            Console.ReadLine();
        }
    }
}

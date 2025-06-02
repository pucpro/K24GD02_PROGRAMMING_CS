using System;
using System.Collections;
using System.Collections.Generic;

namespace Bai1
{
    internal class Program
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Student(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return $"Student(Id={Id}, Name={Name})";
            }
        }

        static void Main(string[] args)
        {
            // ArrayList Example
            ArrayList arraylist = new ArrayList
            {
                "Item 01",
                "Item 02",
                1,
                2
            };

            Console.WriteLine("ArrayList Count: " + arraylist.Count);
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }

            arraylist.Insert(1, "Item 04");

            ArrayList arrayList2 = new ArrayList
            {
                5,
                "Item 6"
            };

            arraylist.AddRange(arrayList2);
            arraylist.Remove(5);

            // Hashtable Example
            Hashtable hashtable = new Hashtable
            {
                { "Key1", "value1" },
                { "Key2", "value2" },
                { "Key3", "value3" },
                { "Key4", 4 },
                { 5, "value5" }
            };

            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            hashtable.Remove("Key3");
            Hashtable hashtable2 = (Hashtable)hashtable.Clone();
            hashtable.Clear();

            // SortedList Example
            SortedList sortedList = new SortedList
            {
                { "First", 1 },
                { "key 2", 2 },
                { "third", "value 3" },
                { "Third", "value 3" }
            };

            SortedList sortedlist2 = (SortedList)sortedList.Clone();
            sortedlist2.Clear();

            // Stack Example
            Stack stack = new Stack();
            stack.Push("Item01");
            stack.Push("Item02");
            stack.Push("Item03");
            stack.Push("Item04");
            stack.Push("Item05");
            stack.Pop();

            // Queue Example
            Queue queue = new Queue();
            queue.Enqueue("Item 01");
            queue.Enqueue("Item 02");
            queue.Enqueue("Item 03");
            queue.Enqueue("Item 04");
            queue.Enqueue("Item 05");
            queue.Dequeue();

            // List<Student> Example
            Console.WriteLine("=== List<Student> ===");
            List<Student> studentList = new List<Student>
            {
                new Student(1, "Alice"),
                new Student(2, "Bob"),
                new Student(3, "Charlie")
            };

            studentList.Add(new Student(4, "David"));
            studentList.Insert(1, new Student(5, "Eva"));
            studentList.RemoveAt(3);
            studentList[2] = new Student(6, "Frank");

            PrintCollection(studentList);
            Console.WriteLine($"Count: {studentList.Count}");
            Console.WriteLine($"Exists student with Id = 2? {studentList.Exists(s => s.Id == 2)}");

            // Dictionary Example
            Dictionary<string, int> ages = new Dictionary<string, int>
            {
                { "Alice", 25 },
                { "Bob", 30 }
            };

            if (ages.ContainsKey("Alice"))
                Console.WriteLine($"Alice is {ages["Alice"]} years old.");

            ages["Alice"] = 26;
            ages.Remove("Bob");

            foreach (var kvp in ages)
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");

            Console.ReadLine();
        }

        static void PrintCollection<T>(List<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        static void QueueExample()
        {
            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Download file");
            tasks.Enqueue("Scan file");
            Console.WriteLine("Next task: " + tasks.Peek());
            Console.WriteLine("Processing: " + tasks.Dequeue());

            foreach (var task in tasks)
                Console.WriteLine(task);
        }

        static void StackExample()
        {
            Stack<string> history = new Stack<string>();
            history.Push("Page 1");
            history.Push("Page 2");
            Console.WriteLine("Current page: " + history.Peek());
            Console.WriteLine("Go back: " + history.Pop());

            foreach (var page in history)
                Console.WriteLine(page);
        }

        static void SortedListExample()
        {
            SortedList<int, string> students = new SortedList<int, string>
            {
                { 102, "Lan" },
                { 101, "Nam" },
                { 105, "Hoa" }
            };

            students[102] = "Linh";

            if (students.ContainsKey(105))
                Console.WriteLine("Student 105: " + students[105]);

            students.Remove(101);

            foreach (var s in students)
                Console.WriteLine($"{s.Key}: {s.Value}");
        }
    }
}
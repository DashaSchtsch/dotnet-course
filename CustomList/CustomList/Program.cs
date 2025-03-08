using System;

namespace CustomList
{
    class Program
    {
        static void Main()
        {
            MyCustomList<int> defaultList = new MyCustomList<int>();
            Console.WriteLine("Default list (capacity: 3)");
            defaultList.Add(1);
            defaultList.Add(2);
            defaultList.Add(3);
            defaultList.Add(4);
            Console.WriteLine("After adding items:");
            PrintList(defaultList);
            Console.WriteLine($"Capacity after adding items: {defaultList.Capacity}\n");

            MyCustomList<int> capacityList = new MyCustomList<int>(5);
            Console.WriteLine("List with capacity 5");
            capacityList.Add(11);
            capacityList.Add(22);
            Console.WriteLine("After adding items:");

            MyCustomList<int> arrayList = new MyCustomList<int>(new int[] { 111, 222, 333 });
            Console.WriteLine("List with array 111, 222, 333");
            PrintList(arrayList);
            Console.WriteLine($"Items count: {arrayList.Count}\n");

            MyCustomList<int> list = new MyCustomList<int>();

            list.Add(8);
            list.Add(0);
            list.Add(3);
            list.Add(7);
            Console.WriteLine("After adding items:");
            PrintList(list);
            Console.WriteLine($"Items count: {list.Count}");

            Console.WriteLine($"Item at index 1: {list[1]}");

            list[1] = 100;
            Console.WriteLine("After changing item at index 1:");
            PrintList(list);

            bool removed1 = list.Remove(3);
            Console.WriteLine($"Remove item '3': {(removed1 ? "success" : "failure")}");
            PrintList(list);

            bool removed2 = list.Remove(45);
            Console.WriteLine($"Remove item '45': {(removed2 ? "success" : "failure")}");
            PrintList(list);

            list.RemoveAtIndex(0);
            Console.WriteLine("After removing item at index 0:");
            PrintList(list);

            Console.WriteLine($"Items count: {list.Count}");
        }

        static void PrintList<T>(MyCustomList<T> list)
        {
            Console.Write("List: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

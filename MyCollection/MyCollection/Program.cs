using System;

namespace MyCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myList = new Collection<int>(5) { 1, 2, 5, 3 };
            var array = new Collection<int> { 5, 2, 7, 5, 4, 9, 6, 5 };

            myList.AddRange(array);
            Console.WriteLine("Before remove");

            Console.WriteLine($"Count = {myList.Count} Capacity = {myList.Capacity}");

            foreach (var item in myList)
            {
                Console.Write($"{item} ");
            }

            myList.Remove(5);
            myList.RemoveAt(5);

            myList.Sort(new CollectionComparer());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("After remove & sort");

            Console.WriteLine($"Count = {myList.Count} Capacity = {myList.Capacity}");

            foreach (var item in myList)
            {
                Console.Write($"{item} ");
            }
        }
    }
}

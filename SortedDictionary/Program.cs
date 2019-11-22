using System;

namespace SortedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionarys<string, string> tree = new SortedDictionarys<string,string>();
            //tree.Root = new Entry<int, int>(34);
            //tree.Root.Left = new Entry<int, int>(32);
            //tree.Root.Right = new Entry<int, int>(43);

            //tree.Get(tree.Root);
            // tree.Insert(1, 10);
            // tree.Insert(2, 20);
            // tree.Insert(3,19);
            //tree.Insert(4, 9);
            // tree.Insert(5, 9);
            // tree.Insert(7, 6);
            // do traversal later; call get with it
            tree.Insert("A", "Apple");
            tree.Insert("B", "Ball");
            tree.Insert("C", "Dimple");

            tree.Insert("D", "Capple");
            Console.WriteLine("before Deletion of Apple " + "the number of item is "+ tree.Count);
            //this is looking good
            //tree.Delete("B");
            //tree.Delete("C");
            //tree.Delete("A");
         //   Console.WriteLine("after Deletion of Apple " + "the number of item is " + tree.Count);
            // Console.WriteLine( tree.Get("D"));
           // tree.clear();
            Console.WriteLine(tree.ContainsKey("A"));
            Console.WriteLine(tree.ContainsValue("Ball"));
            Console.WriteLine(tree.ContainsValue("hhfhghf") + "  Answer should be false");
            Console.WriteLine(tree["D"]);
            //Console.WriteLine(tree.Get("s"));
        //     tree.Inorder();
            //Console.WriteLine( tree.Count);

        }
    }
}

using System;

namespace Data_Structures
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //var list = new MyLIst();
            //list.Add(10);
            //Console.WriteLine(list[0]);
            //list.Add(20);
            //Console.WriteLine(list[1]);
            //list.RemoveAt(1);
            //list.Add(2);
            //list.Insert(1,1234);
            //Console.WriteLine(list.Contains(4523));
            //Console.WriteLine(list.Contains(1234));
            //Console.WriteLine(list[0]);
            //Console.WriteLine(list[1]);
            //Console.WriteLine(list[2]);
            //list.Swap(0,1);
            //Console.WriteLine(list[0]);
            //Console.WriteLine(list[1]);

            var stack = new MyStack();
            stack.Push(10);
            stack.Push(20); 
            

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
        }
    }
}

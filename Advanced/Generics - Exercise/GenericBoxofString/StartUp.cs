using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GenericBoxofString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());
            //var list = new List<double>();
            //for (int i = 0; i < n; i++)
            //{
            //    var input = double.Parse(Console.ReadLine());
            //    list.Add(input);
            //}

            //var box = new Box<double>(list);
            //var element = double.Parse(Console.ReadLine());
            //Console.WriteLine(box.Counter(box.Values, element));
            //var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //var firstIndex = indexes[0];
            //var secondIndex = indexes[1];
            //box.Swap(list, firstIndex, secondIndex);
            //Console.WriteLine(box);

            var firstInput = Console.ReadLine()
                .Split()
                .ToArray();
            var name = $"{firstInput[0]} {firstInput[1]}";
            var address = firstInput[2];
            var town = firstInput[3];
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(name, address, town);

            var secondInput = Console.ReadLine()
                .Split()
                .ToArray();
            var person = secondInput[0];
            var amountBeer = int.Parse(secondInput[1]);
            var drinkOrNot = secondInput[2];
            bool check = true;
            if (drinkOrNot == "not")
            {
                check = false;
            }
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(person, amountBeer, check);

            var thirdInput = Console.ReadLine()
                .Split()
                .ToArray();
            var firstArg = thirdInput[0];
            var secondArg = double.Parse(thirdInput[1]);
            var thirdArg = thirdInput[2];
            Threeuple<string, double,string> thirdTuple = new Threeuple<string, double,string>(firstArg, secondArg,thirdArg);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);



        }
    }
}

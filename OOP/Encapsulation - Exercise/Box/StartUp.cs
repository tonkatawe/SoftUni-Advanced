﻿using System;

namespace Box
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine(box.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

﻿using System;
using WildFarm.Core;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
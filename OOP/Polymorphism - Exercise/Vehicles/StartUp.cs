using System;
using Vehicles.Core;
using Vehicles.Models;

namespace Vehicles
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

using System;
using System.Collections.Generic;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int capacity = 10;

        public int Capacity => capacity;
        public IReadOnlyDictionary<string, IRobot> Robots { get; }
        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count >= capacity)
            {
                throw new InvalidOperationException($"{ExceptionMessages.NotEnoughCapacity}");
            }
            else if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException($"{ExceptionMessages.ExistingRobot}");
            }
            else
            {
                Console.WriteLine("WTF? :)");
            }
        }

        public void Sell(string robotName, string ownerName)
        {
            throw new NotImplementedException();
        }
    }
}

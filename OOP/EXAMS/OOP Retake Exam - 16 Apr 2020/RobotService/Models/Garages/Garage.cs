using System.Linq;

namespace RobotService.Models.Garages
{
    using System;
    using RobotService.Models.Robots;
    using RobotService.Utilities.Messages;
    using System.Collections.Generic;
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Robots.Contracts;

    public class Garage : IGarage
    {
        private const int GarageCapacity = 10;
        private int capacity;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.capacity = 10;
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots
        {
            get => this.robots;
        }
        public void Manufacture(IRobot robot)
        {
            if (Robots.Count >= this.capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (Robots.ContainsKey(robot.Name))
            {
                var exMsg = String.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(exMsg);
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}

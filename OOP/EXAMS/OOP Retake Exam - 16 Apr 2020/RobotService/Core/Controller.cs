


using RobotService.Models.Procedures.Contracts;

namespace RobotService.Core
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using RobotService.Models.Procedures;
    using RobotService.Models.Robots;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    using RobotService.Core.Contracts;
    using RobotService.Models.Garages;
    using RobotService.Models.Garages.Contracts;

    public class Controller : IController
    {
        //123/150 on judge todo: think about procedures history :) 
        private IGarage garage;
        public Controller()
        {
            this.garage = new Garage();
            
        }
        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                //todo: check are make checking about happiness and energy
                var exMsg = String.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(exMsg);
            }
            //todo: check make checking garageCapacity 
            this.garage.Manufacture(robot);
            var result = String.Format(OutputMessages.RobotManufactured, name);
            return result;
        }

        public string Chip(string robotName, int procedureTime)
        {

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }

            var robot = GetRobotByItsName(robotName);
            //todo: Here I am not sure :)
            var chip = new Chip();
            chip.DoService(robot, procedureTime);
            var result = String.Format(OutputMessages.ChipProcedure, robotName);
            return result;
        }

        private IRobot GetRobotByItsName(string robotName)
        {
            return this.garage.Robots.Values.FirstOrDefault(n => n.Name == robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }

            var robot = GetRobotByItsName(robotName);
            var techCheck = new TechCheck();
            techCheck.DoService(robot, procedureTime);
            var result = String.Format(OutputMessages.TechCheckProcedure, robotName);
            return result;
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }
            var robot = GetRobotByItsName(robotName);
            var rest = new Rest();
            rest.DoService(robot, procedureTime);
            var result = String.Format(OutputMessages.RestProcedure, robotName);
            return result;
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }
            var robot = GetRobotByItsName(robotName);
            var work = new Work();
            work.DoService(robot, procedureTime);
            var result = String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return result;
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }
            var robot = GetRobotByItsName(robotName);
            var charge = new Charge();
            charge.DoService(robot, procedureTime);
            var result = String.Format(OutputMessages.ChargeProcedure, robotName);
            return result;
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }
            var robot = GetRobotByItsName(robotName);
            var polish = new Polish();
            polish.DoService(robot, procedureTime);
            var result = String.Format(OutputMessages.PolishProcedure, robotName);
            return result;
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                var exMsg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(exMsg);
            }

            var robot = GetRobotByItsName(robotName);
            this.garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                var sellMsg = String.Format(OutputMessages.SellChippedRobot, ownerName);
                return sellMsg;
            }
            else
            {
                var sellMsg = String.Format(OutputMessages.SellNotChippedRobot, ownerName);
                return sellMsg;
            }
        }

        public string History(string procedureType)
        {
            var result = new StringBuilder();
            result.AppendLine(procedureType);
            foreach (var robot in this.garage.Robots.)
            {
                result.AppendLine(robot.Value.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}


using System.ComponentModel.Design;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            if (robotType == "HouseholdRobot")
            {
                
            }
            else if (robotType == "WalkerRobot")
            {
                
            }
            else if (robotType == "PetRobot")
            {

            }
            else
            {
           //

            }
        }

        public string Chip(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Rest(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Work(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Charge(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Polish(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Sell(string robotName, string ownerName)
        {
            throw new System.NotImplementedException();
        }

        public string History(string procedureType)
        {
            throw new System.NotImplementedException();
        }
    }
}

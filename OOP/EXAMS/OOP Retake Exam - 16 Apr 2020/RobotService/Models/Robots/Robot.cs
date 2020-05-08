using System;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;
        private string owner;
        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }
        public string Name { get; private set; }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < 0 || value > 100) //here might be check for equals
                {
                    throw new ArgumentException($"{ExceptionMessages.InvalidHappiness}");
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0 || value > 100) //here might be check for equals too
                {
                    throw new ArgumentException($"{ExceptionMessages.InvalidEnergy}");
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner
        {
            get => this.owner;
            set
            {
                if (value == null)
                {
                    this.owner = "Service";
                }
            }
        }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(
                $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}");

            return result.ToString().TrimEnd();
        }
    }

}

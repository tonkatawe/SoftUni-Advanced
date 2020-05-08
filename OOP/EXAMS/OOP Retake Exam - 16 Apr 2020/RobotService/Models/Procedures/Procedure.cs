using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public string History()
        {
            var result = new StringBuilder();
            result.AppendLine(this.GetType().Name);
            foreach (var robot in Robots)
            {
                result.AppendLine(robot.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            foreach (var member in Robots)
            {
                if (!(member.Name == robot.Name && member.ProcedureTime >= procedureTime))
                {
                    throw new ArgumentException($"{ExceptionMessages.InsufficientProcedureTime}");
                }
            }

        }

        protected ICollection<IRobot> Robots { get; set; }
    }
}

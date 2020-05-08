using System;
using RobotService.Models.Robots.Contracts;
namespace RobotService.Models.Procedures
{
    public class Chip:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            foreach (var member in this.Robots)
            {
                if (!member.IsChipped)
                {
                    member.IsChipped = true;
                    member.Happiness -= 5;
                }
                else
                {
                    throw new ArgumentException($"{member.Name} is already chipped");
                }
            }
        }
    }
}

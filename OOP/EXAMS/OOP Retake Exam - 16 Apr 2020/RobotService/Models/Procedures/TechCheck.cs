
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
   public class TechCheck:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            foreach (var member in this.Robots)
            {
                if (!member.IsChecked)
                {
                    member.IsChecked = true;
                }

                member.Energy -= 8;
            }
        }
    }
}

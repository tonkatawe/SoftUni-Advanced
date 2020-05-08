
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
   public class Rest:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            foreach (var member in this.Robots)
            {
                member.Happiness -= 3;
                member.Energy += 10;
            }
        }
    }
}


using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
  public  class Work:Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            foreach (var member in this.Robots)
            {
                member.Energy -= 6;
                member.Happiness += 12;
            }
        }
    }
}

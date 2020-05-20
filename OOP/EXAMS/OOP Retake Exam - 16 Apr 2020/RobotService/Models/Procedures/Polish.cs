namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Polish : Procedure
    {
        private const int DecreaseHappiness = 7;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= DecreaseHappiness;
        }
    }
}

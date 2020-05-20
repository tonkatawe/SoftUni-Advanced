
namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    class Work : Procedure
    {
        private const int IncreaseHappiness = 12;
        private const int DecreaseEnergy = 6;

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += IncreaseHappiness;
            robot.Energy -= DecreaseEnergy;
        }
    }
}

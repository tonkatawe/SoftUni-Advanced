namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Charge : Procedure
    {
        private const int IncreaseHappiness = 12;
        private const int IncreaseEnergy = 10;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += IncreaseHappiness;
            robot.Energy += IncreaseEnergy;
        }
    }
}

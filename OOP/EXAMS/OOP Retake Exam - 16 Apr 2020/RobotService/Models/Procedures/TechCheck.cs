namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class TechCheck : Procedure
    {
        private const int DecreaseEnergy = 8;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= DecreaseEnergy;
            if (robot.IsChecked)
            {
                robot.Energy -= DecreaseEnergy;
            }

            robot.IsChecked = true;

        }
    }
}

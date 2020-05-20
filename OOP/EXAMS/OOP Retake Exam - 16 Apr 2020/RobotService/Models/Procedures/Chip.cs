namespace RobotService.Models.Procedures
{
    using System;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    public class Chip : Procedure
    {
        private const int DecreaseHappiness = 5;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if (robot.IsChipped)
            {
                var exMsg = String.Format(ExceptionMessages.AlreadyChipped, robot.GetType().Name);
                throw new ArgumentException(exMsg);
            }

            robot.IsChipped = true;
            robot.Happiness -= DecreaseHappiness;
        }
    }
}

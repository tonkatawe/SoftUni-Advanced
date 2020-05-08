namespace RobotService
{
    using RobotService.Core;
    using RobotService.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //here i recieve 50/50 but i cant believe how ah.. :)
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

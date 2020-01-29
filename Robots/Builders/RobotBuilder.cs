namespace Robots.Builders
{
    public class RobotBuilder : IRobotBuilder
    {
        public IRobot Create(ISurface surface, int x, int y, RobotOrientation orientation)
        {
            return new Robot(surface, x, y, orientation);
        }
    }
}

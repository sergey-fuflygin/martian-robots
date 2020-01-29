namespace Robots.Builders
{
    public interface IRobotBuilder
    {
        IRobot Create(ISurface surface, int x, int y, RobotOrientation orientation);
    }
}

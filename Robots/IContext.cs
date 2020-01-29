using Robots.Builders;

namespace Robots
{
    public interface IContext
    {
        ISurface Surface { get; set; }
        IRobot Robot { get; set; }

        ISurfaceBuilder SurfaceBuilder { get; }
        IRobotBuilder RobotBuilder { get; }
    }
}

using Robots.Builders;

namespace Robots
{
    public class Context : IContext
    {
        public ISurfaceBuilder SurfaceBuilder { get; private set; }
        public IRobotBuilder RobotBuilder { get; private set; }
        public ISurface Surface { get; set; }
        public IRobot Robot { get; set; }

        public Context(ISurfaceBuilder surfaceBuilder, IRobotBuilder robotBuilder)
        {
            SurfaceBuilder = surfaceBuilder;
            RobotBuilder = robotBuilder;
        }
    }
}

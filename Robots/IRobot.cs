namespace Robots
{
    public interface IRobot
    {
        int X { get; }
        int Y { get; }
        RobotOrientation Orientation { get; }
        ISurface Surface { get; }

        void MoveForward();
        void TurnRight();
        void TurnLeft();
    }
}

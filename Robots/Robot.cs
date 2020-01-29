using System;

namespace Robots
{
    public class Robot : IRobot
    {
        public ISurface Surface { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public RobotOrientation Orientation { get; private set; }

        public Robot(ISurface surface, int x, int y, RobotOrientation orientation)
        {
            if (surface == null)
                throw new ArgumentNullException(nameof(surface));

            if (x < surface.MinX || x > surface.MaxX)
                throw new ArgumentOutOfRangeException(nameof(x));

            if (y < surface.MinY || y > surface.MaxY)
                throw new ArgumentOutOfRangeException(nameof(y));

            Surface = surface;
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void MoveForward()
        {
            var lastX = X;
            var lastY = Y;

            switch (Orientation)
            {
                case RobotOrientation.North:
                    Y++;
                    break;
                case RobotOrientation.East:
                    X++;
                    break;
                case RobotOrientation.South:
                    Y--;
                    break;
                case RobotOrientation.West:
                    X--;
                    break;
                default:
                    throw new Exception($"Moving robot oriented {Orientation} is not supported");
            }

            if (Surface.OutOfBoundaries(X, Y))
            {
                X = lastX;
                Y = lastY;
                if (!Surface.IsScentPoint(X, Y))
                {
                    Surface.LeftScent(X, Y);
                    throw new RobotLostException();
                }
            }
        }

        public void TurnRight()
        {
            Orientation = (Orientation == RobotOrientation.West) ? RobotOrientation.North : Orientation + 1;
        }

        public void TurnLeft()
        {
            Orientation = (Orientation == RobotOrientation.North) ? RobotOrientation.West : Orientation - 1;
        }
    }
}

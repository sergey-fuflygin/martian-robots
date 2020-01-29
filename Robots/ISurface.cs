namespace Robots
{
    public interface ISurface
    {
        int MinX { get; }
        int MinY { get; }

        int MaxX { get; }
        int MaxY { get; }
        void LeftScent(int x, int y);
        bool IsScentPoint(int x, int y);
        bool OutOfBoundaries(int x, int y);
    }
}

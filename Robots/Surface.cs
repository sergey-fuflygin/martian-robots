namespace Robots
{
    public class Surface : ISurface
    {
        public int MinX => 0;
        public int MinY => 0;

        public int MaxX { get; }
        public int MaxY { get; }

        private readonly bool[,] scentPoints;

        public Surface(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            scentPoints = new bool[MaxX + 1, maxY + 1];
        }

        public bool IsScentPoint(int x, int y)
        {
            return scentPoints[x, y];
        }

        public void LeftScent(int x, int y)
        {
            scentPoints[x, y] = true;
        }

        public bool OutOfBoundaries(int x, int y)
        {
            return x < MinX || x > MaxX || y < MinY || y > MaxY;
        }
    }
}

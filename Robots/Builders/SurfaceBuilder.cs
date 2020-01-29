namespace Robots.Builders
{
    public class SurfaceBuilder : ISurfaceBuilder
    {
        public ISurface Create(int maxX, int maxY)
        {
            return new Surface(maxX, maxY);
        }
    }
}

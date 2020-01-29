using System;
using System.Text.RegularExpressions;
using Robots.Logging;

namespace Robots.InstructionReaders
{
    public class CreateSurfaceInstructionReader : InstructionReader
    {
        private const string maxXGroupName = "MaxX";
        private const string maxYGroupName = "MaxY";
        private static readonly string regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+)$", maxXGroupName, maxYGroupName);

        public CreateSurfaceInstructionReader(IContext context, ILogger logger)
            : base(regexPattern, context, logger)
        {
        }

        public override void Process(string command)
        {
            if (!Validate(command, out Match match))
                return;

            int maxX = Convert.ToInt32(match.Groups[maxXGroupName].Value);
            int maxY = Convert.ToInt32(match.Groups[maxYGroupName].Value);
            context.Surface = context.SurfaceBuilder.Create(maxX, maxY);
        }
    }
}

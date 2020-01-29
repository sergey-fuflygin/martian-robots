using System;
using System.Text.RegularExpressions;
using Robots.Logging;

namespace Robots.InstructionReaders
{
    public class CreateRobotInstructionReader : InstructionReader
    {
        private const string XPosGroupName = "XPos";
        private const string YPosGroupName = "YPos";
        private const string orientationGroupName = "Orientation";
        private static readonly string regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[n|e|s|w])$", XPosGroupName, YPosGroupName, orientationGroupName);

        public CreateRobotInstructionReader(IContext context, ILogger logger)
            : base(regexPattern, context, logger)
        {
        }

        public override void Process(string command)
        {
            if (!Validate(command, out Match match))
                return;

            int x = Convert.ToInt32(match.Groups[XPosGroupName].Value);
            int y = Convert.ToInt32(match.Groups[YPosGroupName].Value);
            RobotOrientation orientation = ConvertToOrientation(match.Groups[orientationGroupName].Value);

            try
            {
                context.Robot = context.RobotBuilder.Create(context.Surface, x, y, orientation);
            }
            catch (Exception ex)
            {
                logger.Log($"Robot creation failed. {ex}");
            }
        }

        private RobotOrientation ConvertToOrientation(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "n":
                    return RobotOrientation.North;
                case "e":
                    return RobotOrientation.East;
                case "s":
                    return RobotOrientation.South;
                case "w":
                    return RobotOrientation.West;
                default:
                    throw new Exception($"Orientation instruction {value} is not supported");
            }
        }
    }
}
using System;
using System.Globalization;

namespace Robots.Instructions
{
    public class TurnInstruction : IInstruction
    {
        private const string rightCommand = "R";
        private const string leftCommand = "L";

        public bool IsValid(char command)
        {
            string commandAsString = command.ToString(CultureInfo.InvariantCulture);
            return IsLeftCommand(commandAsString)
                || IsRightCommand(commandAsString);
        }

        public bool Execute(char command, IRobot robot)
        {
            if (!IsValid(command))
            {
                return false;
            }

            ProcessCommand(command, robot);
            return true;
        }

        private void ProcessCommand(char command, IRobot robot)
        {
            string commandAsString = command.ToString(CultureInfo.InvariantCulture);
            if (IsLeftCommand(commandAsString))
            {
                robot.TurnLeft();
            }

            if (IsRightCommand(commandAsString))
            {
                robot.TurnRight();
            }
        }

        private bool IsRightCommand(string command)
        {
            return command.Equals(rightCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsLeftCommand(string command)
        {
            return command.Equals(leftCommand, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

using System.Linq;
using System.Collections.Generic;
using Robots.Logging;
using Robots.Instructions;

namespace Robots.InstructionReaders
{
    public class MoveRobotInstructionReader : InstructionReader
    {
        private readonly IList<IInstruction> supportedInstructions;

        public MoveRobotInstructionReader(IContext context, IEnumerable<IInstruction> supportedInstructions, ILogger logger)
            : base("^[l|r|f]+$", context, logger)
        {
            this.supportedInstructions = supportedInstructions.ToList();
        }

        public override void Process(string instructions)
        {
            if (!Validate(instructions))
                return;

            IRobot robot = context.Robot;
            bool lost = false;

            try
            {
                foreach (var instruction in instructions.ToLowerInvariant())
                {
                    IInstruction executer = GetInstruction(instruction);
                    executer.Execute(instruction, robot);
                }
            }
            catch (RobotLostException)
            {
                lost = true;
            }

            logger.Log($"{robot.X} {robot.Y} {robot.Orientation.ToString().Substring(0, 1)}{(lost ? " LOST" : "")}");
        }

        private IInstruction GetInstruction(char character)
        {
            return supportedInstructions.FirstOrDefault(instruction => instruction.IsValid(character));
        }
    }
}

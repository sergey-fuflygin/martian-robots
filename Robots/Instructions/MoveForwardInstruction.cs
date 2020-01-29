namespace Robots.Instructions
{
    public class MoveForwardInstruction : IInstruction
    {
        public bool IsValid(char instruction)
        {
            return instruction == 'F' || instruction == 'f';
        }

        public bool Execute(char instruction, IRobot robot)
        {
            if (robot == null || !IsValid(instruction))
            {
                return false;
            }

            robot.MoveForward();
            return true;
        }
    }
}
namespace Robots.Instructions
{
    public interface IInstruction
    {
        bool IsValid(char instruction);
        bool Execute(char instruction, IRobot robot);
    }
}

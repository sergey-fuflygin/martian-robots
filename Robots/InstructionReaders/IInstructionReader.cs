using System.Text.RegularExpressions;

namespace Robots.InstructionReaders
{
    public interface IInstructionReader
    {
        bool Validate(string instruction);
        bool Validate(string instruction, out Match match);
        void Process(string instruction);
    }
}

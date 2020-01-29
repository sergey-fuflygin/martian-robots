using System.Text.RegularExpressions;
using Robots.Logging;

namespace Robots.InstructionReaders
{
    public abstract class InstructionReader : IInstructionReader
    {
        protected readonly IContext context;
        protected readonly ILogger logger;
        private readonly Regex regex;

        protected InstructionReader(string pattern, IContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
            regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public bool Validate(string command)
        {
            return regex.IsMatch(command);
        }

        public bool Validate(string command, out Match match)
        {
            match = regex.Match(command);
            return match.Success;
        }

        public abstract void Process(string command);
    }
}

using System;
using Ninject;
using Robots.Builders;
using Robots.InstructionReaders;
using Robots.Instructions;
using Robots.Logging;

namespace Robots.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            BuildDependencies(kernel);

            bool exit = false;
            while (!exit)
            {
                var instructions = Console.ReadLine();
                if (instructions == "exit")
                {
                    exit = true;
                    continue;
                }

                foreach (var commandReader in kernel.GetAll<IInstructionReader>())
                {
                    if (!commandReader.Validate(instructions))
                    {
                        continue;
                    }
                    commandReader.Process(instructions);
                    break;
                }
            }
        }

        private static void BuildDependencies(IKernel kernel)
        {
            kernel.Bind<IContext>().To<Context>().InThreadScope();
            kernel.Bind<ISurfaceBuilder>().To<SurfaceBuilder>();
            kernel.Bind<IRobotBuilder>().To<RobotBuilder>();
            kernel.Bind<ILogger>().To<ConsoleLogger>();

            RegisterCommandReaders(kernel);
            RegisterCommands(kernel);
        }

        private static void RegisterCommandReaders(IKernel kernel)
        {
            kernel.Bind<IInstructionReader>().To<CreateSurfaceInstructionReader>();
            kernel.Bind<IInstructionReader>().To<CreateRobotInstructionReader>();
            kernel.Bind<IInstructionReader>().To<MoveRobotInstructionReader>();
        }

        private static void RegisterCommands(IKernel kernel)
        {
            kernel.Bind<IInstruction>().To<TurnInstruction>();
            kernel.Bind<IInstruction>().To<MoveForwardInstruction>();
        }
    }
}

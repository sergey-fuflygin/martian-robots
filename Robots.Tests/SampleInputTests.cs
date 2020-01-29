using Moq;
using NUnit.Framework;
using Robots.Builders;
using Robots.InstructionReaders;
using Robots.Instructions;
using Robots.Logging;
using System.Collections.Generic;

namespace Robots.Tests.RobotTests
{
    [TestFixture]
    public class SampleInputTests
    {
        private Mock<ILogger> logger;
        private IContext context;
        private CreateSurfaceInstructionReader createSurfaceInstructionReader;
        private CreateRobotInstructionReader createRobotInstructionReader;
        private MoveRobotInstructionReader moveRobotInstructionReader;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new Context(new SurfaceBuilder(), new RobotBuilder());
            logger = new Mock<ILogger>();
            createSurfaceInstructionReader = new CreateSurfaceInstructionReader(context, logger.Object);
            createSurfaceInstructionReader.Process("5 3");
            createRobotInstructionReader = new CreateRobotInstructionReader(context, logger.Object);
            var supportedInstructions = new List<IInstruction> { new MoveForwardInstruction(), new TurnInstruction() };
            moveRobotInstructionReader = new MoveRobotInstructionReader(context, supportedInstructions, logger.Object);
        }

        [Test, Order(1)]
        public void SampleInputTests_First()
        {
            //Arrange
            var createRobotInstruction = "1 1 E";
            var moveRobotInstruction = "RFRFRFRF";

            //Act
            createRobotInstructionReader.Process(createRobotInstruction);
            moveRobotInstructionReader.Process(moveRobotInstruction);

            //Assert
            logger.Verify(l => l.Log(It.Is<string>(m => m == "1 1 E")));
        }

        [Test, Order(2)]
        public void SampleInputTests_Second()
        {
            //Arrange
            var createRobotInstruction = "3 2 N";
            var moveRobotInstruction = "FRRFLLFFRRFLL";

            //Act
            createRobotInstructionReader.Process(createRobotInstruction);
            moveRobotInstructionReader.Process(moveRobotInstruction);

            logger.Verify(l => l.Log(It.Is<string>(m => m == "3 3 N LOST")));
        }

        [Test, Order(3)]
        public void SampleInputTests_Third()
        {
            //Arrange
            var createRobotInstruction = "0 3 W";
            var moveRobotInstruction = "LLFFFLFLFL";

            //Act
            createRobotInstructionReader.Process(createRobotInstruction);
            moveRobotInstructionReader.Process(moveRobotInstruction);

            logger.Verify(l => l.Log(It.Is<string>(m => m == "2 3 S")));
        }
    }
}

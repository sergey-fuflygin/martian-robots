using Moq;
using NUnit.Framework;
using Robots.InstructionReaders;
using Robots.Instructions;
using Robots.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Tests
{
    [TestFixture]
    public class MoveRobotInstructionReaderTests
    {
        private Mock<IRobot> robot;
        private MoveRobotInstructionReader moveInstructionReader;

        [SetUp]
        public void Setup()
        {
            robot = new Mock<IRobot>();
            var context = new Mock<IContext>();
            var logger = new Mock<ILogger>();
            var supportedInstructions = new List<IInstruction> { new MoveForwardInstruction(), new TurnInstruction() };

            context.SetupGet(c => c.Robot).Returns(robot.Object);

            moveInstructionReader = new MoveRobotInstructionReader(context.Object, supportedInstructions, logger.Object);
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToMoveForwardOnce_RobotMovesOnce()
        {
            //Arrange   
            string instruction = "F";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.MoveForward(), Times.Once());
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToMoveForwardFiveTimes_RobotMovesFiveTimes()
        {
            //Arrange
            string instruction = "FFFFF";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.MoveForward(), Times.Exactly(5));
        }

        [Test]
        public void ProcessMoveRobotInstruction_InvalidCommand_RobotDoesNotMove()
        {
            //Arrange
            string instruction = "B";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.MoveForward(), Times.Never());
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToTurnRight_RobotTurnsRightOnce()
        {
            //Arrange
            string instruction = "R";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.TurnRight(), Times.Once());
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToTurnRightFourTimes_RobotTurnsRightFourTimes()
        {
            //Arrange
            string instruction = "RRRR";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            this.robot.Verify(r => r.TurnRight(), Times.Exactly(4));
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToTurnLeft_RobotTurnsLeftOnce()
        {
            //Arrange
            string instruction = "L";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.TurnLeft(), Times.Once());
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToTurnLeftFourTimes_RobotTurnsLeftFourTimes()
        {
            //Arrange
            string instruction = "LLLL";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.TurnLeft(), Times.Exactly(4));
        }

        [Test]
        public void ProcessMoveRobotInstruction_RobotAskedToMoveForwardThreeTimesTurnRightOnceMoveForwardTwice_RobotMovesThreeTimesThenTurnsRightThenMovesTwice()
        {
            //Arrange
            string instruction = "FFFRFF";

            //Act
            moveInstructionReader.Process(instruction);

            //Assert
            robot.Verify(r => r.MoveForward(), Times.Exactly(5));
            robot.Verify(r => r.TurnRight(), Times.Once());
        }
    }
}

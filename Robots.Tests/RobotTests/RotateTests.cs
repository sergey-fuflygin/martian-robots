using NUnit.Framework;

namespace Robots.Tests.RobotTests
{
    [TestFixture]
    public class TurnTests : RobotTestsBase
    {
        [Test]
        public void TurnRight_RobotOrientedNorth_RobotOrientedEast()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.North);

            //Act
            robot.TurnRight();

            //Assert
            Assert.AreEqual(RobotOrientation.East, robot.Orientation);
        }

        [Test]
        public void TurnRight_RobotOrientedEast_RobotOrientedSouth()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.East);

            //Act
            robot.TurnRight();

            //Assert
            Assert.AreEqual(RobotOrientation.South, robot.Orientation);
        }

        [Test]
        public void TurnRight_RobotOrientedSouth_RobotOrientedWest()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.South);

            //Act
            robot.TurnRight();

            //Assert
            Assert.AreEqual(RobotOrientation.West, robot.Orientation);
        }

        [Test]
        public void TurnRight_RobotOrientedWest_RobotOrientedNorth()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.West);

            //Act
            robot.TurnRight();

            //Assert
            Assert.AreEqual(RobotOrientation.North, robot.Orientation);
        }

        [Test]
        public void TurnLeft_RobotOrientedNorth_RobotOrientedWest()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.North);

            //Act
            robot.TurnLeft();

            //Assert
            Assert.AreEqual(RobotOrientation.West, robot.Orientation);
        }

        [Test]
        public void TurnLeft_RobotOrientedWest_RobotOrientedSouth()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.West);

            //Act
            robot.TurnLeft();

            //Assert
            Assert.AreEqual(RobotOrientation.South, robot.Orientation);
        }

        [Test]
        public void TurnLeft_RobotOrientedSouth_RobotOrientedEast()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.South);

            //Act
            robot.TurnLeft();

            //Assert
            Assert.AreEqual(RobotOrientation.East, robot.Orientation);
        }

        [Test]
        public void TurnLeft_RobotOrientedEast_RobotOrientedNorth()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.East);

            //Act
            robot.TurnLeft();

            //Assert
            Assert.AreEqual(RobotOrientation.North, robot.Orientation);
        }
    }
}

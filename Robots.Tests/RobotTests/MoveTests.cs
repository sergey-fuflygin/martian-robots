using NUnit.Framework;

namespace Robots.Tests.RobotTests
{
    [TestFixture]
    public class MoveTests : RobotTestsBase
    {
        [Test]
        public void MoveForward_RobotOrientedNorth_RobotYIncreasesByOne()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.North);

            //Act
            robot.MoveForward();

            //Assert
            Assert.AreEqual(1, robot.Y);
        }

        [Test]
        public void MoveForward_RobotOrientedEast_RobotXIncreasesByOne()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.East);

            //Act
            robot.MoveForward();

            //Assert
            Assert.AreEqual(1, robot.X);
        }

        [Test]
        public void MoveForward_RobotOrientedSouth_RobotYDecreasesByOne()
        {
            //Arrange
            var robot = new Robot(surface.Object, maxCoordinate, maxCoordinate, RobotOrientation.South);

            //Act
            robot.MoveForward();

            //Assert
            Assert.AreEqual(maxCoordinate - 1, robot.Y);
        }

        [Test]
        public void MoveForward_RobotOrientedWest_RobotXDecreasesByOne()
        {
            //Arrange
            var robot = new Robot(surface.Object, maxCoordinate, maxCoordinate, RobotOrientation.West);

            //Act
            robot.MoveForward();

            //Assert
            Assert.AreEqual(maxCoordinate - 1, robot.X);
        }

        [Test]
        public void MoveForward_RobotOnLeftEdgeOfSurfaceOrientedWest_RobotLost()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.West);

            //Act & Assert
            Assert.Throws<RobotLostException>(robot.MoveForward);
        }

        [Test]
        public void MoveForward_RobotOnBottomEdgeOfSurfaceOrientedSouth_RobotLost()
        {
            //Arrange
            var robot = new Robot(surface.Object, 0, 0, RobotOrientation.South);

            //Act & Assert
            Assert.Throws<RobotLostException>(robot.MoveForward);
        }

        [Test]
        public void MoveForward_RobotOnTopEdgeOfSurfaceOrientedNorth_RobotLost()
        {
            //Arrange
            var robot = new Robot(surface.Object, maxCoordinate, maxCoordinate, RobotOrientation.North);

            //Act & Assert
            Assert.Throws<RobotLostException>(robot.MoveForward);
        }

        [Test]
        public void MoveForward_RobotOnRightEdgeOfSurfaceOrientedEast_RobotLost()
        {
            //Arrange
            var robot = new Robot(surface.Object, maxCoordinate, maxCoordinate, RobotOrientation.East);

            //Act & Assert
            Assert.Throws<RobotLostException>(robot.MoveForward);
        }

        [Test]
        public void MoveForward_RobotOnRightEdgeOfSurfaceWithScentOrientedEast_RobotDoesNotMove()
        {
            //Arrange
            surface.Setup(s => s.IsScentPoint(maxCoordinate, maxCoordinate)).Returns(true);
            var robot = new Robot(surface.Object, maxCoordinate, maxCoordinate, RobotOrientation.East);

            //Act & Assert
            Assert.DoesNotThrow(robot.MoveForward);
            Assert.AreEqual(maxCoordinate, robot.X);
            Assert.AreEqual(maxCoordinate, robot.Y);
        }
    }
}

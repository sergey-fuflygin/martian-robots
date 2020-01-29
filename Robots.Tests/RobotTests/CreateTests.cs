using System;
using NUnit.Framework;

namespace Robots.Tests.RobotTests
{
    [TestFixture]
    public class CreateTests : RobotTestsBase
    {
        [Test]
        public void Create_RobotWithoutSurface_ExceptionThrown()
        {
            //Arrange

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Robot(null, 0, 0, RobotOrientation.North));
        }

        [Test]
        public void Create_RobotOutOfLeftEdge_ExceptionThrown()
        {
            //Arrange
            var x = surface.Object.MinX - 1;
            var y = surface.Object.MinY;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Robot(surface.Object, x, y, RobotOrientation.North));
        }

        [Test]
        public void Create_RobotOutOfRightEdge_ExceptionThrown()
        {
            //Arrange
            var x = surface.Object.MaxX + 1;
            var y = surface.Object.MinY;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Robot(surface.Object, x, y, RobotOrientation.North));
        }

        [Test]
        public void Create_RobotOutOfBottomEdge_ExceptionThrown()
        {
            //Arrange
            var x = surface.Object.MinX;
            var y = surface.Object.MinY - 1;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Robot(surface.Object, x, y, RobotOrientation.North));
        }

        [Test]
        public void Create_RobotOutOfTopEdge_ExceptionThrown()
        {
            //Arrange
            var x = surface.Object.MinX;
            var y = surface.Object.MaxY + 1;

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Robot(surface.Object, x, y, RobotOrientation.North));
        }
    }
}

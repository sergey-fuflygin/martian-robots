using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Tests.RobotTests
{
    public class RobotTestsBase
    {
        protected Mock<ISurface> surface;
        //protected Robot robot;
        protected const int maxCoordinate = 5;
        //protected const int validCoordinate = 3;
        //protected const int invalidCoordinate = 10;

        [SetUp]
        public virtual void Setup()
        {
            surface = new Mock<ISurface>();
            surface.SetupGet(s => s.MaxX).Returns(maxCoordinate);
            surface.SetupGet(s => s.MaxY).Returns(maxCoordinate);
            surface.Setup(s => s.OutOfBoundaries(It.Is<int>(x => x < 0 || x > maxCoordinate), It.IsAny<int>())).Returns(true);
            surface.Setup(s => s.OutOfBoundaries(It.IsAny<int>(), It.Is<int>(y => y < 0 || y > maxCoordinate))).Returns(true);

            //surface.Setup(s => s.OutOfBoundaries(It.IsNotIn(0, maxCoordinate), It.IsNotIn(0, maxCoordinate))).Returns(true);
            //robot = new Robot(surface, )
        }
    }
}

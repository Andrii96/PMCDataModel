using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;

namespace PMCDataModelTests
{
    //TODO: For all tests, edge cases are not covered
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Create1DPoint_PointCreated()
        {
            Point1D<int> point; 
            point = new Point1D<int>(5);

            Assert.IsNotNull(point);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Create2DPoint_ExceptionThrown()
        {
            Point2D<char> point;
            point = new Point2D<char>('1','2');
        }

        [TestMethod]
        public void CheckPointType_2DPointType()
        {
            Point2D<int> point = new Point2D<int>(1, 2);

            Assert.IsTrue(point.GetPointType() == Point<int>.PointType.Point2d);
        }
    }
}

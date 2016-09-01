using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;

namespace PositionTest
{
    [TestClass]
   public  class PositionTests
    {
        [TestMethod]
        public void Constructor_Empty_InstanceCreated()
        {
            //arrange
            Position<int> position = new Position<int>();

            //assert
            Assert.IsInstanceOfType(position, typeof(Position<int>));
        }

        [ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public void Constructor_Empty_Exception()
        {
            //arrange
            Position<string> position = new Position<string>();
        }

        [TestMethod]
        public void Add_Point_ElementAdded()
        {
            //arrange
            Point3D<int> point = new Point3D<int>(2, 3, 1);
            Position<Point3D<int>> position = new Position<Point3D<int>>();

            //action
            position.Add(point);

            //assert
            Assert.IsTrue(position.Contains(point));
        }
    }
}

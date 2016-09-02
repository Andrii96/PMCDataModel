using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;
using System.Collections.Generic;

namespace PositionTest
{
    [TestClass]
    public class PositionTests
    {
        private Position<int> position;

        [TestMethod]
        public void EmptyConstructor_AllowedType_InstanceCreated()
        {
            position = new Position<int>();
            Assert.IsNotNull(position);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void EmptyConstructor_NotAllowedType_ExceptionThrown()
        {
            Position<char> position = new Position<char>();
        }

        [TestMethod]
        public void ParametrizedConstructor_ListPoints_InstanceCreated()
        {
            List<Point<int>> points = new List<Point<int>>();
            points.Add(new Point2D<int>(1, 2));
            points.Add(new Point2D<int>(3, 2));

            position = new Position<int>(points);

            Assert.IsNotNull(position);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ParametrizedConstructor_ListPoints_ExceptionThrown()
        {
            List<Point<int>> points = new List<Point<int>>();
            points.Add(new Point2D<int>(1, 2));
            points.Add(new Point3D<int>(3, 2,2));

            position = new Position<int>(points);
        }

        [TestMethod]
        public void Add_Point_PointAdded()
        {
            position = new Position<int>();
            var point = new Point2D<int>(1, 2);

            position.Add(point);

            Assert.IsTrue(position.Count == 1);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_Point_ExceptionThrown()
        {
            position = new Position<int>();
            var point1 = new Point2D<int>(1, 2);
            var point2 = new Point3D<int>(1, 2, 3);

            position.Add(point1);
            position.Add(point2);

        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Add_NullPoint_ExceptionThrown()
        {
            position = new Position<int>();
            Point3D<int> point1=null; 

            position.Add(point1);

        }
    }
}

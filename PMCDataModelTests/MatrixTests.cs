using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;
using System.Collections.Generic;

namespace PositionTest
{
    [TestClass]
    public class MatrixTests
    {
        private static int _pointsCount;
        private static int _positionsCount;
        private static List<Point3D<int>> _pointsList = new List<Point3D<int>>();
        private static List<Position<Point3D<int>>> _positionsList = new List<Position<Point3D<int>>>();
        private static Matrix<Position<Point3D<int>>> _matrix;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Random random = new Random();
            _pointsCount = random.Next(3, 100);
            _positionsCount = random.Next(1, 10);

            for (int i=0; i < _pointsCount; i++)
            {
                _pointsList.Add(new Point3D<int>(random.Next(100), random.Next(100), random.Next(100)));
            }

            for(int i = 0; i < _positionsCount; i++)
            {
                _positionsList.Add(new Position<Point3D<int>>(_pointsList));
            }

            _matrix = new Matrix<Position<Point3D<int>>>(_positionsList);            
        }

        [ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public void Constructor_Empty_ExceptionThrown()
        {
            Matrix<Position<string>> matrix = new Matrix<Position<string>>();
        }

        [TestMethod]
        public void Add_Position3D_ElementAdded()
        {
            Position<Point3D<int>> newPosition = new Position<Point3D<int>>(_pointsList);

            _matrix.Add(newPosition);

            Assert.IsTrue(_matrix.Contains(newPosition));
           
        }

        [TestMethod]
        public void Add_Position2D_ElementAdded()
        {
            var matrix = new Matrix<Position<Point2D<int>>>();
            var position1 = new Position<Point2D<int>>(new Point2D<int>(1, 2), new Point2D<int>(8, 9));
            var position2 = new Position<Point2D<int>>(new Point2D<int>(1, 2));

            matrix.Add(position1);
            matrix.Add(position2);

            Assert.IsTrue(matrix.Contains(position1) && matrix.Contains(position2));
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Add_Position3D_ExceptionThrown()
        {
            Position<Point3D<int>> newPosition = new Position<Point3D<int>>();
            newPosition.Add(new Point3D<int>(1, 2, 3));

            _matrix.Add(newPosition);
        }

    }
}

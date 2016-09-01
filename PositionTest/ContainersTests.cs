using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;
using System.Collections.Generic;

namespace PositionTest
{
    [TestClass]
    public class ContainersTests
    {
        private static List<Point3D<int>> _points3DList = new List<Point3D<int>>();
        private static List<Point2D<int>> _points2DList = new List<Point2D<int>>();

        private static List<Position<Point3D<int>>> _positions3DList = new List<Position<Point3D<int>>>();
        private static List<Position<Point2D<int>>> _positions2DList = new List<Position<Point2D<int>>>();

        private static Matrix<Position<Point3D<int>>> _matrix3D;
        private static Matrix<Position<Point2D<int>>> _matrix2D;

        private static Container _container;
        private static Containers<Container> _containers = new Containers<Container>();

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Random random = new Random();
            int _pointsCount = random.Next(3, 100);
            int _positionsCount = random.Next(3, 10);

            for (int i = 0; i < _pointsCount; i++)
            {
                _points3DList.Add(new Point3D<int>(random.Next(100), random.Next(100), random.Next(100)));
                _points2DList.Add(new Point2D<int>(random.Next(100), random.Next(100)));

            }

            for (int i = 0; i < _positionsCount; i++)
            {
                _positions3DList.Add(new Position<Point3D<int>>(_points3DList));
                _positions2DList.Add(new Position<Point2D<int>>(_points2DList.GetRange(0, _positionsCount - i)));
            }

            _matrix3D = new Matrix<Position<Point3D<int>>>(_positions3DList);
            _matrix2D = new Matrix<Position<Point2D<int>>>(_positions2DList);

            _container = new Container(_matrix2D, _matrix3D);

            _containers.Add(_container);

        }

        [TestMethod]
        public void Add_Container_ElementAdded()
        {
            var newContainer = _container;
            _containers.Add(newContainer);

            Assert.IsTrue(_containers.Contains(newContainer));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_HasDifferentMatrixNumberContainer_ExceptionThrown()
        {
            Container container = new Container(_matrix2D);
            _containers.Add(container);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_HasDifferentIndexedMatrixTypeContainer_ExceptionThrown()
        {
            Container container = new Container(_matrix3D, _matrix2D);
            _containers.Add(container);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_HasDifferentNumberOfPositionsIn3DMatrixContainer_ExceptionThrown()
        {
            Matrix<Position<Point3D<int>>> matrix = new Matrix<Position<Point3D<int>>>(_positions3DList.GetRange(0,2));
            Container container = new Container(_matrix2D, matrix);
            _containers.Add(container);
        }
    }
}

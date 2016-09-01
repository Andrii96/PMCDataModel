using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PMCDataModel;

namespace PositionTest
{
    [TestClass]
    public class ContainerTests
    {

        private static List<Point3D<int>> _points3DList = new List<Point3D<int>>();
        private static List<Point2D<int>> _points2DList = new List<Point2D<int>>();

        private static List<Position<Point3D<int>>> _positions3DList = new List<Position<Point3D<int>>>();
        private static List<Position<Point2D<int>>> _positions2DList = new List<Position<Point2D<int>>>();

        private static Matrix<Position<Point3D<int>>> _matrix3D;
        private static Matrix<Position<Point2D<int>>> _matrix2D;

        private static Container _container;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Random random = new Random();
            int _pointsCount = random.Next(3, 100);
            int _positionsCount = random.Next(1, 10);

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
        }

        [TestMethod]
        public void Add_Matrix_ElementAdded()
        {
            var newMatrix =  new Matrix<Position<Point2D<int>>>(_positions2DList);

            _container.Add(newMatrix);

            Assert.IsTrue(_container.Contains(newMatrix));
        }

        [ExpectedException(typeof(ArrayTypeMismatchException))]
        [TestMethod]
        public void Add_WrongTypeMatrix_ExceptionThrown()
        {
            _container.Add(new Point2D<int>(1,2));
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Add_WrongMatrix_ExceptionThrown()
        {
            var matrix = new Matrix<Position<Point2D<int>>>(_positions2DList.GetRange(0,2));
            _container.Add(matrix);
        }
    }
}

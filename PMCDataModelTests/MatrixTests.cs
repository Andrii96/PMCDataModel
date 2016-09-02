using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;
using System.Collections.Generic;

namespace PositionTest
{
    [TestClass]
    public class MatrixTests
    {
        private static Matrix<int> _matrix;
        private static List<Position<int>> _positionsList;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Random rand = new Random();
            int positionsNumber = rand.Next(3, 10);

            _positionsList = new List<Position<int>>();

            for (int i = 0; i < positionsNumber; i++)
            {
                _positionsList.Add(Position<int>.CreatePosition(Point<int>.PointType.Point2d, 3));
            }

            _matrix = new Matrix<int>(_positionsList);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void EmptyConstructor_ExceptionThrown()
        {
            var matrix = new Matrix<char>();            
        }

        [TestMethod]
        public void EmptyConstructor_Create3DMatrix_InstanceCreated()
        {
            List<Position<int>> _positionsList = new List<Position<int>>();

            _positionsList.Add(Position<int>.CreatePosition(Point<int>.PointType.Point3d, 3));
            _positionsList.Add(Position<int>.CreatePosition(Point<int>.PointType.Point3d, 3));

            var matrix = new Matrix<int>(_positionsList);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void EmptyConstructor_Create3DMatrix_ExceptionThrown()
        {
            List<Position<int>> _positionsList = new List<Position<int>>();

            _positionsList.Add(Position<int>.CreatePosition(Point<int>.PointType.Point3d, 3));
            _positionsList.Add(Position<int>.CreatePosition(Point<int>.PointType.Point3d, 2));

            var matrix = new Matrix<int>(_positionsList);
        }

        [TestMethod]
        public void Add_Position_PositionAdded()
        {
            var newPosition = Position<int>.CreatePosition(Point<int>.PointType.Point2d, 5);

            _matrix.Add(newPosition);

            Assert.IsTrue(_matrix.ElementsList.Contains(newPosition));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_Position_ExceptionThrown()
        {
            var newPosition = Position<int>.CreatePosition(Point<int>.PointType.Point3d, 5);

            _matrix.Add(newPosition);
        }


    }
}

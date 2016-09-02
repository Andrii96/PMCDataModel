using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PMCDataModel;

namespace PositionTest
{
    [TestClass]
    public class ContainerTests
    {
        private static List<Matrix<int>> _matrixes;
        private static Container<int> _container;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _matrixes = new List<Matrix<int>>();

            Random rand = new Random();
            int count = rand.Next(3, 12);

            for(int i=0; i<count;i++)
            {
                if(i%2==0)
                {
                    _matrixes.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point2d, 6));
                }
                else if(i%3==0)
                {
                    _matrixes.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point3d, 6));
                }
                else
                {
                    _matrixes.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point1d, 6));
                }
                
            }

            _container = new Container<int>();

            foreach(var matrix in _matrixes)
            {
                _container.Add(matrix);
            }
        }

        [TestMethod]
        public void Add_Matrix_ElementAdded()
        {
            var matrix = Matrix<int>.CreateMatrix(Point<int>.PointType.Point2d, 6);

            _container.Add(matrix);

            Assert.IsTrue(_container.ElementsList.Contains(matrix));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_Matrix_ExceptionThrown()
        {
            var matrix = Matrix<int>.CreateMatrix(Point<int>.PointType.Point2d, 2);

            _container.Add(matrix);

            Assert.IsTrue(_container.ElementsList.Contains(matrix));
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Add_EmptyMatrix_ExceptionThrown()
        {
            var matrix = new Matrix<int>();

            _container.Add(matrix);

        }

    }
}

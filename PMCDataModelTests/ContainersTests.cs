using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMCDataModel;
using System.Collections.Generic;

namespace PositionTest
{
    [TestClass]
    public class ContainersTests
    {
        private static Containers<int> _containers;
        private static List<Container<int>> _containerList;
        private static List<Matrix<int>> _matrices;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Random rand = new Random();
            int count = rand.Next(1, 10);

            _matrices = new List<Matrix<int>>();

            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    _matrices.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point2d, 10));
                }
                else
                {
                    _matrices.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point3d, 10));
                }

            }

            _containerList = new List<Container<int>>();

            for (int i = 0; i < 10; i++)
            {
                var container = new Container<int>();
                foreach (var item in _matrices)
                {
                    container.Add(item);
                }
                _containerList.Add(container);
            }

            _containers = new Containers<int>(_containerList);

        }

        [TestMethod]
        public void Add_Container_ElementAdded()
        {
            _containers.Add(_containerList[0]);

            Assert.IsTrue(_containers.ElementsList.Contains(_containerList[0]));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_DiffAmountOfMatrixContainer_ExceptionThrown()
        {
            var container = Container<int>.CreateContainer(1);
            _containers.Add(container);
        }

         [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_DiffTypeOfIndexedMatrices_ExceptionThrown()
        {
            var list = new List<Matrix<int>>();
            for (int i = 0; i < _matrices.Count; i++)
            {
                list.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point1d, 10));
            }

            var container = new Container<int>();
            foreach (var item in list)
            {
                container.Add(item);
            }

            _containers.Add(container);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Add_DiffNumberOfPositionIn3DIndexedMatrices_ExceptionThrown()
        {
            var container = new Container<int>();
            var list = new List<Matrix<int>>();
            for (int i = 0; i < _matrices.Count; i++)
            {
                if(i==1)
                {
                    list.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point3d, 10));
                }else
                {
                    list.Add(Matrix<int>.CreateMatrix(Point<int>.PointType.Point3d, 9));
                }               
            }

            foreach (var item in list)
            {
                container.Add(item);
            }

            var containers = new Containers<int>();
            containers.Add(container);
        }
    }
  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Class for representation collection of containers
    /// </summary>
    /// 
    public class Containers<T>:Collection<Container<T>> where T:struct
    {
       
        #region Constructors

        /// <summary>
        /// Initializes containers instance. Throws ArgumentException if wrong generic type
        /// </summary>
        public Containers() : base() { }

        /// <summary>
        /// Initializes containers instance with container list. Throws ArgumentException if wrong generic type
        /// </summary>
        public Containers(List<Container<T>> containers): this()
        {
            if (CheckContainersOnMatrixAmount(containers)
               && CheckTypeOfEachIndexedMatrix(containers)
               && CheckNumberofDataPointsIn3dMatrix(containers))
            {
                base.FillCollection(new List<Container<T>>(containers));
            }

            else
            {
                string message = "Each container should have the same number of matrix and each indexed matrix should have the same type";
                throw new ArgumentException(message);
            }
        }

        // <summary>
        /// Initializes containers instance with container array. Throws ArgumentException if wrong generic type
        /// </summary>
        public Containers(params Container<T>[] containers) : this(containers.ToList()) { }

        #endregion

        #region Methods

        /// <summary>
        /// Adds new element to the collection
        /// </summary>
        /// <param name="container">Element for adding</param>
        public override void Add(Container<T> container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            if (ElementsList.Count > 0)
            {
                var lastContainer = ElementsList.Last();

                if (CheckContainersOnMatrixAmount(container, lastContainer) &&
                   CheckTypeOfEachIndexedMatrix(container, lastContainer) &&
                   CheckNumberofDataPointsIn3dMatrix(container, lastContainer))
                {
                    base.AddElement(container);
                }
                else
                {
                    string message = "Each container should have the same number of matrix and each indexed matrix should have the same type";
                    throw new ArgumentException(message);
                }
            }
            else
            {
                base.AddElement(container);
            }
        }

        /// <summary>
        /// String representation of containers
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ElementsList.Count; i++)
            {
                string containerName = string.Format("Container{0}:\n ", i + 1);
                sb.Append(containerName);
                sb.Append(ElementsList[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Factory method for creating containers
        /// </summary>
        /// <param name="containersNumber"> Number of containers</param>
        /// <param name="numberOfMatrices">Number of matrices in each container</param>
        /// <param name="numberPositions">Number of positions in each matrix </param>
        /// <returns></returns>
        public static Containers<T> Create (int containersNumber, int numberOfMatrices, int numberOfPositions)
        {
            Random rand = new Random();
            
            List<Matrix<T>> matrices = new List<Matrix<T>>();
            List<Container<T>> containers = new List<Container<T>>();

            for(int i=0; i<numberOfMatrices; i++)
            {
                Matrix<T> matrix;
                if (i%2==0)
                {
                   matrix = Matrix<T>.CreateMatrix(Point<T>.PointType.Point1d, numberOfPositions);
                }else if(i%3 == 0)
                {
                   matrix = Matrix<T>.CreateMatrix(Point<T>.PointType.Point2d, numberOfPositions);
                }
                else
                {
                    matrix = Matrix<T>.CreateMatrix(Point<T>.PointType.Point3d, numberOfPositions);
                }

                matrices.Add(matrix);
            }

            for(int i=0; i<containersNumber;i++)
            {
                var container = new Container<T>();
                foreach (var item in matrices)
                {
                    container.Add(item);
                }
                containers.Add(container);
            }

            return new Containers<T>(containers);

        }

         #endregion

        #region Helpers

        private bool CheckContainersOnMatrixAmount(List<Container<T>> containers)
        {
            for (int i = 1; i < containers.Count; i++)
            {
                if (!CheckContainersOnMatrixAmount(containers[0], containers[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckTypeOfEachIndexedMatrix(List<Container<T>> containers)
        {
            for (int i = 1; i < containers.Count; i++)
            {
                if (!CheckTypeOfEachIndexedMatrix(containers[0], containers[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckNumberofDataPointsIn3dMatrix(List<Container<T>> containers)
        {
            for (int i = 1; i < containers.Count; i++)
            {
                if (!CheckNumberofDataPointsIn3dMatrix(containers[0], containers[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckContainersOnMatrixAmount(Container<T> container1, Container<T> container2)
        {
            return container1.ElementsList.Count == container2.ElementsList.Count;
        }

        private bool CheckTypeOfEachIndexedMatrix(Container<T> container1, Container<T> container2)
        {
            for (int i = 0; i < container1.ElementsList.Count; i++)
            {
                if (container1.ElementsList[i].ElementsList[i].ElementsList[0].GetPointType() !=
                    container2.ElementsList[i].ElementsList[i].ElementsList[0].GetPointType())
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckNumberofDataPointsIn3dMatrix(Container<T> container1, Container<T> container2)
        {
            for (int i = 0; i < container1.ElementsList.Count; i++)
            {
                var matrix = container1.ElementsList[i];
                if (matrix.ElementsList[0].ElementsList[0].GetPointType() == Point<T>.PointType.Point3d)
                {
                    if (GetAmountOfDataPointsFor3DMatrix(matrix) != GetAmountOfDataPointsFor3DMatrix(container2.ElementsList[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private int GetAmountOfDataPointsFor3DMatrix(Matrix<T> matrix)
        {
            return matrix.ElementsList[0].ElementsList.Count;
        }

        #endregion
    }
    
}

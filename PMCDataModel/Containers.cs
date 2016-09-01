using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Class for representation collection of containers
    /// </summary>
    public class Containers<T> : Collection<T> where T: Container
    {
        #region Constructor
        /// <summary>
        /// Empty constructor for initializing Containers instance
        /// </summary>
        public Containers() { }

        /// <summary>
        /// Parametrized constructor for initializing Containers instance. Throws ArgumentException if parameter doesnt match requirements
        /// </summary>
        /// <param name="containers"></param>
        public Containers(List<T> containers)
        {
            if (CheckContainersOnMatrixAmount(containers)
               && CheckTypeOfEachIndexedMatrix(containers)
               && CheckNumberofDataPointsIn3dMatrix(containers))
            {
                CollectionList = containers;
            }

            else
            {
                string message = "Each container should have the same number of matrix and each indexed matrix should have the same type";
                throw new ArgumentException(message);
            }
        }

        public Containers (params T[] containers) : this(containers.ToList()) { }
        #endregion

        #region Methods

        /// <summary>
        /// Method for adding new container to Containers collection
        /// </summary>
        /// <param name="item">Item for adding to collection</param>
        public override void Add(T item)
        {
            if(CollectionList.Count > 0)
            {
                T container = CollectionList.Last();

                if (CheckContainersOnMatrixAmount(container, item) &&
                   CheckTypeOfEachIndexedMatrix(container, item) &&
                   CheckNumberofDataPointsIn3dMatrix(container, item))
                {
                    CollectionList.Add(item);
                }
                else
                {
                    string message = "Each container should have the same number of matrix and each indexed matrix should have the same type";
                    throw new ArgumentException(message);
                }
            }
            else
            {
                CollectionList.Add(item);
            }            
        }

        /// <summary>
        /// String representation of containers
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < CollectionList.Count; i++)
            {
                string containerName = string.Format("Container{0}:\n ", i + 1);
                sb.Append(containerName);
                sb.Append(CollectionList[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool CheckContainersOnMatrixAmount(List<T> containers)
        {
            for(int i=1; i<containers.Count;i++)
            {
                if(!CheckContainersOnMatrixAmount(containers[0],containers[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckTypeOfEachIndexedMatrix(List<T> containers)
        {
            for(int i=1; i<containers.Count;i++)
            {
                if(!CheckTypeOfEachIndexedMatrix(containers[0],containers[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckNumberofDataPointsIn3dMatrix(List<T> containers)
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

        private bool CheckContainersOnMatrixAmount(T container1, T container2)
        {
            return container1.Count == container2.Count;
        }

        private bool CheckTypeOfEachIndexedMatrix(T container1, T container2)
        {
            for(int i=0; i<container1.Count; i++)
            {
                if(container1.MatrixCollection[i].GetType() != container2.MatrixCollection[i].GetType())
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckNumberofDataPointsIn3dMatrix(T container1, T container2)
        {
            for(int i=0; i<container1.Count; i++)
            {
                var matrix = container1.MatrixCollection[i];
                if (matrix is Matrix<Position<Point3D<int>>> || matrix is Matrix<Position<Point3D<double>>> || matrix is Matrix<Position<Point3D<decimal>>>)
                {
                    if(GetAmountOfDataPointsFor3DMatrix(matrix)!=GetAmountOfDataPointsFor3DMatrix(container2.MatrixCollection[i]))
                    {
                        return false;
                    }
                }
            }
            return true;               
        }

        private int GetAmountOfDataPointsFor3DMatrix(object matrix)
        {
            var positions = matrix.GetType().GetProperty("CollectionList").GetValue(matrix);
            return (int)positions.GetType().GetProperty("Count").GetValue(positions);                      
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Non generic class for storing matrices
    /// </summary>
    public class Container : Collection<object> 
    {
        #region Constructor

        /// <summary>
        /// Parametrized constructor. Throws NotSupportedException if generic type is wrong.
        /// </summary>
        /// <param name="matrices">List of objects</param>
        public Container(List<object> matrices)
        {
            foreach (var item in matrices)
            {
                if(!IsMatrixType(item))
                {
                    throw new NotSupportedException("Wrong generic type.You can use only Matrix<Position<>> type.");

                }
            }
            CollectionList = matrices;
        }

        // <summary>
        /// Parametrized constructor. Throws NotSupportedException if generic type is wrong.
        /// </summary>
        /// <param name="matrices">Array of objects</param>
        public Container(params object[] matrices) : this(matrices.ToList()) { }

        #endregion

        #region Property
        /// <summary>
        /// Property for getting collection of matrices
        /// </summary>
        public List<object> MatrixCollection
        {
            get { return CollectionList; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method for adding matrix into collection.
        /// Throws ArrayTypeMismatchException if adding item is not Matrix<> type
        /// Throws InvalidOperationException when adding wrong matrix 
        /// </summary>
        /// <param name="item">Iten for adding</param>
        public override void Add(object item)
        {
            if (!IsMatrixType(item))
            {
                string message = "You can't save the instance of such type in Container. The type you can store is Matrix<>.";
                throw new ArrayTypeMismatchException(message);
            }
            else
            {
                if (CollectionList.Count > 0)
                {
                    if (!CheckMatrix(CollectionList[CollectionList.Count - 1], item))
                    {
                        string message = "Every matrix in container should have the same amount of positions.";
                        throw new InvalidOperationException(message);
                    }
                }
                CollectionList.Add(item);
            }
        }

        /// <summary>
        /// String representation of container
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < CollectionList.Count; i++)
            {
                string matrixName = string.Format("  Matrix{0}:\n ", i + 1);
                sb.Append(matrixName);
                sb.Append(CollectionList[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool IsMatrixType(object o)
        {
            return o.GetType().Equals(typeof(Matrix<Position<int>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<double>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<decimal>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<Point2D<int>>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<Point2D<decimal>>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<Point2D<double>>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<Point3D<int>>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<Point3D<decimal>>>)) ||
                    o.GetType().Equals(typeof(Matrix<Position<Point3D<double>>>));
        }

        private bool CheckMatrix(object matrix1, object matrix2)
        {
            return GetCount(matrix1) == GetCount(matrix2);
        }

        private int GetCount(object matrix)
        {
            return (int)matrix.GetType().GetProperty("Count").GetValue(matrix);
        }

        #endregion
    }
}

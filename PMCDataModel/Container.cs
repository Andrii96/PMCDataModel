using System;
using System.Linq;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Non generic class for storing matrices
    /// </summary>
    public class Container<T>:Collection<Matrix<T>> where T:struct
    {
        #region Constructors

        /// <summary>
        /// Initializes container instance. Throws ArgumentException if wrong generic type
        /// </summary>
        public Container() : base() { }

        #endregion

        #region Methods

        /// <summary>
        /// Adds element to the collection
        /// </summary>
        /// <param name="matrix">Element for adding</param>
        public override void Add(Matrix<T> matrix)
        {
            if (matrix == null || matrix.Count == 0)
            {
                throw new ArgumentNullException("The argument is null");
            }

            if (ElementsList.Count > 0)
            {
                if (!CheckMatrix(ElementsList.Last(), matrix))
                {
                    string message = "Every matrix in container should have the same amount of positions.";
                    throw new ArgumentException(message);
                }
            }
            base.AddElement(matrix);

        }

        /// <summary>
        /// String representation of container
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ElementsList.Count; i++)
            {
                string matrixName = string.Format("  Matrix{0}:\n ", i + 1);
                sb.Append(matrixName);
                sb.Append(ElementsList[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Factory method for creating container
        /// </summary>
        /// <param name="numberPositions">Number of matrices in container</param>
        /// <returns></returns>
        public static Container<T> CreateContainer(int numberOfMatrices) 
        {
            Container<T> container = new Container<T>();

            for(int i=0; i< numberOfMatrices; i++)
            {
                if(i%2==0)
                {
                    container.Add(Matrix<T>.CreateMatrix(Point<T>.PointType.Point1d, 10));
                }else if(i%4==0)
                {
                    container.Add(Matrix<T>.CreateMatrix(Point<T>.PointType.Point2d, 6));
                }
                else
                {
                    container.Add(Matrix<T>.CreateMatrix(Point<T>.PointType.Point3d, 12));
                }
                 
            }

            return container;

        }

        #endregion

        #region Helpers

        private bool CheckMatrix(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return matrix1.ElementsList.Count == matrix2.ElementsList.Count;
        }

        #endregion
    }
}

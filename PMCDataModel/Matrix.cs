using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Class for representation matrix of positions
    /// </summary>
    /// <typeparam name="T">Position type</typeparam>
    public class Matrix<T>: Collection<T> 
    {
        #region Constructor

        /// <summary>
        /// Empty constructor. Throws NotSupportedException if generic type is incompatible
        /// </summary>
        public Matrix()
        {
            if (!IsSupportedType())
            {
                throw new NotSupportedException("Wrong generic type.You can use only Position<> type.");
            }
        }

        /// <summary>
        /// Parametrized constructor. Throws NotSupportedException if generic type is not supported or InvalidOperationException  if 3d matrix has different elements in positions
        /// </summary>
        /// <param name="positions"> Positions array for storing in matrix</param>
        public Matrix(params T[] positions) : this()
        {
            if (IsMatrix3D())
            {
                if (!Check3DMatrix(positions))
                {
                    string message = "For 3D matrix amount of data points in each position should be equal.";
                    throw new InvalidOperationException(message);
                }
            }

            foreach (var item in positions)
            {
                CollectionList.Add(item);
            }
        }

        // <summary>
        /// Parametrized constructor. Throws NotSupportedException if generic type is not supported or InvalidOperationException  if 3d matrix has different elements in positions
        /// </summary>
        /// <param name="positions"> Positions list for storing in matrix</param>
        public Matrix(List<T> positions) : this(positions.ToArray()) { }

        #endregion

        #region Methods

        /// <summary>
        /// Method for saving new position in matrix
        /// </summary>
        /// <param name="item">Position for adding</param>
        public override void Add(T item)
        {
            if (CollectionList.Count > 0)
            {
                if (IsMatrix3D())
                {
                    if (!Check3DMatrix(CollectionList.Last(), item))
                    {
                        string message = "For 3D matrix amount of data points in each position should be equal.";
                        throw new InvalidOperationException(message);
                    }
                }
            }

            CollectionList.Add(item);
        }

        /// <summary>
        /// String representation of matrix
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < CollectionList.Count; i++)
            {
                string positionName = string.Format("    Position{0}: ", i + 1);
                sb.Append(positionName);
                sb.Append(CollectionList[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        protected override bool IsSupportedType()
        {
            return  typeof(T).Equals(typeof(Position<int>)) ||
                    typeof(T).Equals(typeof(Position<decimal>)) ||
                    typeof(T).Equals(typeof(Position<double>)) ||
                    typeof(T).Equals(typeof(Position<Point2D<int>>)) ||
                    typeof(T).Equals(typeof(Position<Point2D<double>>)) ||
                    typeof(T).Equals(typeof(Position<Point2D<decimal>>)) ||
                    typeof(T).Equals(typeof(Position<Point3D<int>>)) ||
                    typeof(T).Equals(typeof(Position<Point3D<double>>)) ||
                    typeof(T).Equals(typeof(Position<Point3D<decimal>>));              
        }

        #endregion

        #region Helpers

        private bool IsMatrix3D()
        {
            return typeof(T).Equals(typeof(Position<Point3D<int>>))||
                   typeof(T).Equals(typeof(Position<Point3D<double>>))||
                   typeof(T).Equals(typeof(Position<Point3D<decimal>>));
        }

        private bool Check3DMatrix(T[] positions)
        {
            for (int i = 1; i < positions.Length; i++)
            {
                if(!Check3DMatrix(positions[0],positions[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool Check3DMatrix(T position1, T position2)
        { 
            return (int)position1.GetType().GetProperty("Count").GetValue(position1) ==
                    (int)position2.GetType().GetProperty("Count").GetValue(position2);
        }

        #endregion

    }
}

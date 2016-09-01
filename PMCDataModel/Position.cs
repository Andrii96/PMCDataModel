using System;
using System.Collections.Generic;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Class for representation position of points
    /// </summary>
    /// <typeparam name="T">1D - any numeric C# type, 2D - Point2D struct, 3D - Point3D struct</typeparam>

    public class Position<T> : Collection<T>
    {
        #region Constructor

        /// <summary>
        /// Empty constructor, throws NotSupportedException if object is being initialized with unsupported generic type
        /// </summary>
        public Position()
        {
            if (!IsSupportedType())
            {
                throw new NotSupportedException("Wrong generic type.You can use only int, double,decimal, Point2D<> and Point3D<> types.");
            }
        }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="points">List of points for storing in position</param>
        public Position(List<T> points) : this()
        {
            CollectionList = points;
        }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="points">Array of points</param>
        public Position(params T[] points):this(new List<T>(points)) { }

        #endregion

        #region Methods

        /// <summary>
        /// Method for adding new item to position collection
        /// </summary>
        /// <param name="item">Item for adding</param>
        public override void Add(T item)
        {
            CollectionList.Add(item);
        }

        /// <summary>
        /// String representation of position
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" ");

            for (int i = 0; i < CollectionList.Count; i++)
            {
                sb.Append(CollectionList[i].ToString());
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        protected override bool IsSupportedType()
        {
            var type = typeof(T);

            if (type.Equals(typeof(int)) ||
               type.Equals(typeof(double)) ||
               type.Equals(typeof(decimal)) ||
               type.Equals(typeof(Point2D<int>))||
               type.Equals(typeof(Point2D<double>)) ||
               type.Equals(typeof(Point2D<decimal>)) ||
               type.Equals(typeof(Point3D<int>))||
               type.Equals(typeof(Point3D<double>)) ||
               type.Equals(typeof(Point3D<decimal>)) )
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}

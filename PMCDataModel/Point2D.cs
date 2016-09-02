using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCDataModel
{
    /// <summary>
    /// Represents 2D point
    /// </summary>
    /// <typeparam name="T">C# numeric type</typeparam>
   public class Point2D<T>:Point<T> where T:struct
    {
        #region Fields
        private T _x;
        private T _y;
        #endregion

        #region Properties
        /// <summary>
        /// Gets x value of 2d point
        /// </summary>
        public T X
        {
            get { return _x; }
        }

        /// <summary>
        /// Gets y value of 2d point
        /// </summary>
        public T Y
        {
            get { return _y; }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes 2D point
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        public Point2D(T x, T y)
        {
            _x = x;
            _y = y;
        }
        #endregion

        #region Methods

        public override PointType GetPointType()
        {
            return Point<T>.PointType.Point2d;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }

        #endregion
    }
}

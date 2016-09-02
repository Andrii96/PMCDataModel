using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCDataModel
{
    /// <summary>
    /// Class for representation 1D point
    /// </summary>
    /// <typeparam name="T">C# numerical type</typeparam>
    public class Point1D<T> : Point<T> where T:struct
    {
        #region Field

        private T _x;

        #endregion

        #region Property

        /// <summary>
        /// Gets x value of 1D point
        /// </summary>
        public T X
        {
            get { return _x; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes point
        /// </summary>
        /// <param name="x"></param>
        public Point1D(T x)
        {
            _x = x;
        }

        #endregion

        #region Methods

        public override PointType GetPointType()
        {
            return Point<T>.PointType.Point1d;
        }

        public override string ToString()
        {
            return X.ToString();
        }

        #endregion

    }
}

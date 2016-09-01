using System;

namespace PMCDataModel
{
    /// <summary>
    /// Structure for representation 2D point
    /// </summary>
    /// <typeparam name="T"> Any numeric C# type</typeparam>
    public struct Point2D<T> where T: struct
    {
        #region Fields
            private T _x;
            private T _y;
        #endregion

        #region Constructor
            /// <summary>
            /// Constructor for initializing 2D point
            /// </summary>
            /// <param name="x"> Any numeric value</param>
            /// <param name="y">Any numeric value</param>
            public Point2D(T x, T y)
            {
                if(typeof(T).Equals(typeof(int)) || typeof(T).Equals(typeof(double)) || typeof(T).Equals(typeof(decimal)))
                {
                    _x = x;
                    _y = y;
                }
                else
                {
                    throw new NotSupportedException("You can not initialize struct with this type. Please, use numeric C# types: int,double,decimal.");
                }
                    
            }
        #endregion

        #region Properties
            /// <summary>
            /// Readonly property for getting x value from the point
            /// </summary>
            public T X
            {
                get { return _x; }
            }

            /// <summary>
            /// Readonly property for getting y value from the point
            /// </summary>
            public T Y
            {
                get { return _y; }
            }
        #endregion

        #region Methods
        /// <summary>
        /// String representation of 2D point
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
        #endregion

    }

    /// <summary>
    /// Structure for representation 3D point
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Point3D<T> where T: struct
    {
        #region Fields
            private Point2D<T> _point;
            private T _z;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializing 3D point
        /// </summary>
        /// <param name="x">Any numeric value</param>
        /// <param name="y">Any numeric value</param>
        /// <param name="z">Any numeric value</param>
        public Point3D (T x, T y, T z)
            {
                if (typeof(T).Equals(typeof(int)) || typeof(T).Equals(typeof(double)) || typeof(T).Equals(typeof(decimal)))
                {
                    _point = new Point2D<T>(x, y);
                    _z = z;
                }else
                {
                    throw new InvalidOperationException("You can not initialize struct with this type. Please, use numeric C# types: int,double,decimal.");

                }
            }
            
        #endregion

        #region Properties
            
            /// <summary>
            /// Readonly property for getting x value of the point
            /// </summary>
            public T X
            {
                get { return _point.X; }
            }

            /// <summary>
            /// Readonly property for getting y value of the point
            /// </summary>
            public T Y
            {
                get { return _point.Y; }
            }

            /// <summary>
            /// Readonly property for getting z value of the point
            /// </summary>
            public T Z
            {
                get { return _z; }
            }
        #endregion

        #region Methods
        /// <summary>
        /// String representation of 3D point
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
        #endregion
    }

}

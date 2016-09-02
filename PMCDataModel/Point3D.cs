using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCDataModel
{
   /// <summary>
   /// Represents 3D point
   /// </summary>
   /// <typeparam name="T">C$ numeric type</typeparam>
       
   public class Point3D<T>:Point<T> where T:struct
    {
        #region Fields
            private T _x;
            private T _y;
            private T _z;
        #endregion

        #region Properties
            /// <summary>
            /// Gets x value of 3D point
            /// </summary>
            public T X
            {
                get { return _x; }
            }
            
            /// <summary>
            /// Gets y value of 3D point
            /// </summary>
            public T Y
            {
                get { return _y; }
            }

            /// <summary>
            /// Gets z value of 3D point
            /// </summary>
            public T Z
            {
                get { return _z; }
            }
        #endregion

        #region Constructor

        public Point3D(T x, T y, T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        #endregion

        #region Methods

        public override PointType GetPointType()
        {
            return Point<T>.PointType.Point3d;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }

        #endregion
    }
}

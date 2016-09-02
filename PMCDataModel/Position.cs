using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Repesents indexed points
    /// </summary>
    /// <typeparam name="T">Any C# numeric type</typeparam>

    public class Position<T>:Collection<Point<T>> where T: struct
    {
      
        #region Constructors
        
        /// <summary>
        /// Initializes Position instance
        /// </summary>
        public Position() : base() { }

        /// <summary>
        /// Initializes Position instance with list of points
        /// </summary>
        /// <param name="points">List of points</param>
        public Position(List<Point<T>> points)
        {
            if(!HaveOneTypePoint(points))
            {
                throw new ArgumentException("The points in list are of different type.");
            }

            base.FillCollection(points);
        }

        /// <summary>
        /// Initializes Position instance with array of points
        /// </summary>
        /// <param name="points"></param>
        public Position(params Point<T>[] points):this(new List<Point<T>>(points)) { }

        #endregion

        #region Methods

        /// <summary>
        /// Adds new point into position
        /// </summary>
        /// <param name="point">Point for adding</param>
        public override void Add(Point<T> point)
        {
            if(point == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            if(ElementsList.Count > 0)
            {
                if(!AreTheSameType(ElementsList[ElementsList.Count-1],point))
                {
                    throw new ArgumentException("Points should be at the same type.");
                }
            }
            base.AddElement(point);

        }

        /// <summary>
        /// String representation of position
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" ");

            for (int i = 0; i < ElementsList.Count; i++)
            {
                sb.Append(ElementsList[i].ToString());
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public static Position<T> CreatePosition(Point<T>.PointType type, int number)
        {
            List<Point<T>> points = new List<Point<T>>();
            Random rand = new Random();

            for(int i=0; i<number;i++)
            {
                switch(type)
                {
                    case Point<T>.PointType.Point1d:
                        points.Add(new Point1D<T>((dynamic)rand.Next()));
                        break;
                    case Point<T>.PointType.Point2d:
                        points.Add(new Point2D<T>((dynamic)rand.Next(), (dynamic)rand.Next()));
                        break;
                    case Point<T>.PointType.Point3d:
                        points.Add(new Point3D<T>((dynamic)rand.Next(), (dynamic)rand.Next(), (dynamic)rand.Next()));
                        break;
                }
                
            }

            return new Position<T>(points);
        }
       
        #endregion

        #region Helpers

        private bool AreTheSameType(Point<T> point1,Point<T> point2)
        {
            return point1.GetPointType() == point2.GetPointType();
        }

        private bool HaveOneTypePoint(List<Point<T>> points)
        {
            for(int i=1; i<points.Count; i++)
            {
                if(!AreTheSameType(points[0],points[i]))
                {
                    return false;
                }
            }

            return true;
        }
        
        #endregion
    }
}

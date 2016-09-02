using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PMCDataModel
{
    /// <summary>
    /// Represents matrix of positions
    /// </summary>
    /// <typeparam name="T">Position type</typeparam>
    
    public class Matrix<T>: Collection<Position<T>> where T:struct
    {     
        #region Constructors

        /// <summary>
        /// Initializes Matrix instance. Throws ArgumentException if wrong generic type
        /// </summary>
        public Matrix() : base() { }

        /// <summary>
        /// Initializes Matrix instance with positions list. Throws ArgumentException if wrong generic type
        /// </summary>
        public Matrix(List<Position<T>> positions) : this(positions.ToArray()) { }

        /// <summary>
        /// Initializes Matrix instance with positions array. Throws ArgumentException if wrong generic type
        /// </summary>
        public Matrix(params Position<T>[] positions):base()
        {
            if(!CheckMatrix(positions.ToList()))
            {
                throw new ArgumentException("All positions should be the same type");
            }

            if(positions[0].ElementsList[0].GetPointType() == Point<T>.PointType.Point3d)
            {
                if (!Check3DMatrix(positions))
                {
                    throw new ArgumentException("3D matrix should have the same number of points in each position");
                }
            }
            base.FillCollection(new List<Position<T>>(positions));
        }
       
        #endregion

        #region Methods
        
        /// <summary>
        /// Adds new position into matrix
        /// </summary>
        /// <param name="position">Position</param>
        public override void Add(Position<T> position)
        {
            if (position == null)
            {
                throw new ArgumentNullException("The argument is null");
            }

            if (ElementsList.Count > 0)
            {
                if(!AreTheSameType(ElementsList.Last(),position))
                {
                    throw new ArgumentException("All positions should be the same type");
                }

                if (IsMatrix3D())
                {
                    if (!Check3DMatrix(ElementsList.Last(),position))
                    {
                        string message = "For 3D matrix amount of data points in each position should be equal.";
                        throw new ArgumentException(message);
                    }
                }
            }

            base.AddElement(position);
        }

        /// <summary>
        /// String representation of matrix
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ElementsList.Count; i++)
            {
                string positionName = string.Format("    Position{0}: ", i + 1);
                sb.Append(positionName);
                sb.Append(ElementsList[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// Factory method for creating matrix
        /// </summary>
        /// <param name="type">Matrix type</param>
        /// <param name="numberPositions"> Number of positions</param>
        /// <returns></returns>
        public static Matrix<T> CreateMatrix(Point<T>.PointType type, int numberPositions)
        {
            List<Position<T>> positions = new List<Position<T>>();
            Random rand = new Random();
            if(type == Point<T>.PointType.Point3d)
            {
                for (int i = 0; i < numberPositions; i++)
                {
                    positions.Add(Position<T>.CreatePosition(type, 10));
                }
            }else
            {
                for (int i = 0; i < numberPositions; i++)
                {
                    positions.Add(Position<T>.CreatePosition(type, rand.Next(1,10)));
                }
            }

            return new Matrix<T>(positions);
            
        }

        #endregion

        #region Helpers

        private bool IsMatrix3D()
        {          
            return ElementsList[0].ElementsList[0].GetPointType() == Point<T>.PointType.Point3d;
        }

        private bool AreTheSameType(Position<T> pos1, Position<T> pos2)
        {
            if((pos1.Count == 0) || (pos2.Count == 0))
            {
                return true;
            }
            return pos1.ElementsList[0].GetPointType() == pos2.ElementsList[0].GetPointType();
        }

        private bool CheckMatrix(List<Position<T>> positions)
        {
            for(int i=1;i<positions.Count;i++)
            {
                if(!AreTheSameType(positions[0],positions[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private bool Check3DMatrix(Position<T> pos1, Position<T> pos2)
        {
            return pos1.ElementsList.Count == pos2.ElementsList.Count;
        }

        private bool Check3DMatrix(Position<T>[] positions)
        {
            for (int i = 1; i < positions.Length; i++)
            {
                if (!Check3DMatrix(positions[0], positions[i]))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
   
}

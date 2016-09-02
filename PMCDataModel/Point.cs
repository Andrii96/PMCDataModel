
namespace PMCDataModel
{
    /// <summary>
    /// Abstract class for representation point
    /// </summary>
    /// <typeparam name="T"> C# numeric type</typeparam>
    public abstract class Point<T>:NumericType<T> where T:struct
    {
        /// <summary>
        /// Enum with points types
        /// </summary>
        public enum PointType
        {
            Point1d,
            Point2d,
            Point3d
        };

        /// <summary>
        /// Gets points type
        /// </summary>
        /// <returns>Points type</returns>
        public abstract PointType GetPointType();
    }
}

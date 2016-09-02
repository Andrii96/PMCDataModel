using System;
using System.Collections.Generic;
using PMCDataModel;

namespace ClientApplication
{
    class Program
    {  
        static void Main(string[] args)
        {
            //A Container collection contains 3 containers. All data are decimal.
            //Each matrix contains 100 positions
            //Each container contains 2 matrices with the first matrix in each container being XY data
            //and the second matrix in each container being X data.
            //Position1 of the XY data contains 50 points.
            //Position2 of the XY data contains 200 points. The other XY positions are empty.
            //Position 1 and 2 of the X data matrix contain a numerical value, the others do not.
            try
            {
                //creating XY positions
                var position1XY = Position<decimal>.CreatePosition(Point<decimal>.PointType.Point2d, 50);
                var position2XY = Position<decimal>.CreatePosition(Point<decimal>.PointType.Point2d, 200);

                List<Position<decimal>> XYPositionsList = new List<Position<decimal>>();

                //adding position1XY and position2XY to the positionXY list
                XYPositionsList.Add(position1XY);
                XYPositionsList.Add(position2XY);

                //creating X positions
                var position1X = Position<decimal>.CreatePosition(Point<decimal>.PointType.Point1d, 50);
                var position2X = Position<decimal>.CreatePosition(Point<decimal>.PointType.Point1d, 20);

                List<Position<decimal>> XPositionsList = new List<Position<decimal>>();

                //adding position1X and position2X to the positionX list
                XPositionsList.Add(position1X);
                XPositionsList.Add(position2X);

                for (int i = 2; i < 100; i++)
                {
                    XYPositionsList.Add(new Position<decimal>());
                    XPositionsList.Add(new Position<decimal>());
                }

                //Initializing matrices
                var matrix1 = new Matrix<decimal>(XYPositionsList);
                var matrix2 = new Matrix<decimal>(XPositionsList);

                List<Container<decimal>> containers = new List<Container<decimal>>();

                //Creating each container and fill it with matrices
                for (int i = 0; i < 3; i++)
                {
                    var container = new Container<decimal>();
                    container.Add(matrix1);
                    container.Add(matrix2);

                    containers.Add(container);
                }

                //Creating collection of containers
                var containersCollection = new Containers<decimal>(containers);

                Console.WriteLine(containersCollection.ToString());

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}

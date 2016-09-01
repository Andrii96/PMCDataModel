using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMCDataModel;

namespace ClientApplication
{
    class Program
    {     
        static void Main(string[] args)
        {
            //declaring two lists of 2D points
            List<Point2D<int>> firstXYPointsList = new List<Point2D<int>>(50);
            List<Point2D<decimal>> secondXYPointsList = new List<Point2D<decimal>>(200);

            //declaring two lists of 1D point
            List<decimal> XPointList1 = new List<decimal>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<double> XPointList2 = new List<double>();

            //initializing points
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    XPointList2.Add(i + 3);
                }

                for (int i = 0; i < firstXYPointsList.Capacity; i++)
                {
                    firstXYPointsList.Add(new Point2D<int>(i, i + 1));
                }

                for (int i = 0; i < firstXYPointsList.Capacity; i++)
                {
                    secondXYPointsList.Add(new Point2D<decimal>(i, i + 1));
                }


            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                //initializing position of 1D decimal points
                Position<decimal> firstPosition = new Position<decimal>(XPointList1);

                //initializing position of 2D int point
                Position<Point2D<int>> secondPosition = new Position<Point2D<int>>(firstXYPointsList);

                //initializing position of 2D int point
                Position<Point2D<int>> thirdPosition = new Position<Point2D<int>>() { new Point2D<int>(1, 2), new Point2D<int>(3, 4) };

                //initializing position of 2D decimal point
                Position<Point2D<decimal>> fourthPosition = new Position<Point2D<decimal>>(secondXYPointsList);

                //initializing 2D int matrix
                Matrix<Position<Point2D<int>>> firstMatrix = new Matrix<Position<Point2D<int>>>(secondPosition, secondPosition, thirdPosition, thirdPosition, secondPosition);
                
                //initializing 1D decimal matrix
                Matrix<Position<decimal>> secondMatrix = new Matrix<Position<decimal>>() { firstPosition, firstPosition, firstPosition, firstPosition, firstPosition };

                Container container = new Container();

                container.Add(firstMatrix);
                container.Add(secondMatrix);

                CollectionCreator<Container> containersCreatorFactory = new ContainersCreator<Container>();
                var containers = containersCreatorFactory.Create();

                for (int i = 0; i < 10; i++)
                {
                    containers.Add(container);
                }

                Console.WriteLine(containers.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}

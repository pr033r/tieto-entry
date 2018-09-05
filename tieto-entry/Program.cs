using System;
using System.Collections.Generic;

namespace tieto_entry {

    class Program {

        static void Main(string[] args) {

            AppData appDataDirectory = new AppData();
            Log.init(appDataDirectory.path);

            List<_2dObject> squareObjects = new List<_2dObject>();


            //squareObjects.read(Path.Combine(appDataDirectory.path, "test2.xml"));
            //squareObjects.write(Path.Combine(appDataDirectory.path, "test2.xml"), new _2dObjects(new double[] { 1, 2, 3 }));


            squareObjects.Add(new Square(5.6));
            squareObjects.Add(new Square(400.658));
            squareObjects.Add(new Square(151.2));
            squareObjects.Add(new Rectangle(40.3, 5));
            squareObjects.Add(new Rectangle(20.8, 50.7));
            squareObjects.Add(new Rectangle(3.8, 60.981));
            squareObjects.Add(new Triangle(1, 1, 1.41));
            squareObjects.Add(new Triangle(20, 40, 44.72456));
            squareObjects.Add(new Triangle(5, 3, 7));

            Console.WriteLine("\n === 2dObjectCoordinator methods ===");
            Console.WriteLine(_2dObjectCoordinator.getTrianglesPeriphery(squareObjects, max: true));

            foreach (var item in _2dObjectCoordinator.getPythagoreanTriangles(squareObjects)) {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(_2dObjectCoordinator.getRectanglePeriphery(squareObjects, min: true));
            Console.WriteLine(_2dObjectCoordinator.getSquarePeriphery(squareObjects, min: true));


            Console.WriteLine("\n === 2dObject instances ===");
            Square square = new Square();
            square.Edges = new double[] { 5.565656, 5.565656, 5.565656, 5.565656 };

            Rectangle rectangle = new Rectangle(1.654, 8.1958);
            Triangle triangle = new Triangle();
            triangle.Edges = new double[] { 10, 10, 5 };

            Console.WriteLine(triangle);

            Console.ReadKey();
        }

    }

}

using System;
using System.Collections.Generic;
using System.IO;

namespace tieto_entry {

    class Program {

        static void Main(string[] args) {

            AppData appDataDirectory = new AppData();
            Log.init(appDataDirectory.path);

            StorageFactory storageFactory = new StorageFactory();
            List<_2dObject> squareObjects = new List<_2dObject>();
            _2dObjectCoordinator squareObjectsCoordinator = new _2dObjectCoordinator();

            _2dObject testWrite = new _2dObject();
            string pathToDataFileToBeWrite = Path.Combine(appDataDirectory.path, "test.xml");
            testWrite.write(storageFactory.getXMLManager(), pathToDataFileToBeWrite, new _2dObject());

            _2dObject testLoad = new _2dObject();
            string pathToDataFile = Path.Combine(appDataDirectory.path, "test.xml");
            testLoad.read(storageFactory.getXMLManager(), pathToDataFile);

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
            Console.WriteLine(squareObjectsCoordinator.getTrianglesPeriphery(squareObjects, min: true));
            Console.WriteLine(squareObjectsCoordinator.isTriangle(new _2dObject(new double[] { 5, 5, 1 })));

            foreach (var item in squareObjectsCoordinator.getPythagoreanTriangles(squareObjects)) {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(squareObjectsCoordinator.getRectanglePeriphery(squareObjects, min: true));
            Console.WriteLine(squareObjectsCoordinator.getSquarePeriphery(squareObjects, min: true));


            Console.WriteLine("\n === 2dObject instances ===");
            Square square = new Square();
            square.Edges = new double[] { 5.565656, 5.565656, 5.565656, 5.565656 };

            Rectangle rectangle = new Rectangle(1.654, 8.1958);
            Triangle triangle = new Triangle();
            triangle.Edges = new double[] { 10, 10, 5 };

            Console.WriteLine(square);
            Console.WriteLine(rectangle);
            Console.WriteLine(triangle);

            Console.ReadKey();
        }

    }

}

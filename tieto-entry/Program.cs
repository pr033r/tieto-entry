using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace tieto_entry {

    class Program {

        static void Main(string[] args) {

            AppData appDataDirectory = new AppData();
            Log.init(appDataDirectory.path);
            StorageFactory storageFactory = new StorageFactory();

            _2dObject testObject = new _2dObject();
            string readFile = ConfigurationManager.AppSettings["readFile"];
            string writeFile = ConfigurationManager.AppSettings["writeFile"];

            string pathToDataFile = Path.Combine(appDataDirectory.path, readFile);
            string pathToDataFileToBeWrite = Path.Combine(appDataDirectory.path, writeFile);

            List<_2dObject> squareObjects = testObject.read(storageFactory.getXMLManager(), pathToDataFile);

            Console.WriteLine("\n === 2dObjectCoordinator methods ===");
            Console.WriteLine("isTriangle( 5, 5, 1 ): {0}", _2dObjectCoordinator.isTriangle(new _2dObject(new double[] { 5, 5, 1 })));
            Console.WriteLine("isSquare( 1, 1, 1, 1, 1 ): {0}", _2dObjectCoordinator.isSquare(new _2dObject(new double[] { 1, 1, 1, 1, 1 })));
            Console.WriteLine("isRectangle( 1, 2, 1, 1 ): {0}", _2dObjectCoordinator.isRectangle(new _2dObject(new double[] { 1, 2, 1, 1})));

            Console.WriteLine("\ngetTrianglesPeriphery(...) MIN:\n{0}", _2dObjectCoordinator.getTrianglesPeriphery(squareObjects, min: true));
            Console.WriteLine("\ngetSquarePeriphery(...) MAX:\n{0}", _2dObjectCoordinator.getSquarePeriphery(squareObjects, max: true));
            Console.WriteLine("\ngetRectanglePeriphery(...) MIN:\n{0}", _2dObjectCoordinator.getRectanglePeriphery(squareObjects, min: true));

            Console.WriteLine("\ngetPythagoreanTriangles(...):");
            foreach (var item in _2dObjectCoordinator.getPythagoreanTriangles(squareObjects)) {
                Console.WriteLine(item.ToString());
            }

            squareObjects.RemoveAt(1);
            squareObjects.RemoveAt(2);
            squareObjects.RemoveAt(3);
            
            testObject.write(storageFactory.getXMLManager(), squareObjects, pathToDataFileToBeWrite);

            Console.ReadKey();
        }

    }

}

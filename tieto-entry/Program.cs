using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class Program {

        static void Main(string[] args) {

            AppData appDataDirectory = new AppData();
            Log.init(appDataDirectory.path);

            StorageFactory storageFactory = new StorageFactory(); // DEV ONLY

            _2dObjects squareObjects = new _2dObjects();
            squareObjects.read(Path.Combine(appDataDirectory.path, "test2.xml"));
            //squareObjects.write(Path.Combine(appDataDirectory.path, "test2.xml"), new _2dObjects(new double[] { 1, 2, 3 }));

            Square square = new Square(5);
            Rectangle rectangle = new Rectangle(3, 5);
            Triangle triangle = new Triangle(1, 1, 1.41);

            Console.WriteLine("Square: {0}", square);
            Console.WriteLine("Rectangle: {0}", rectangle);
            Console.WriteLine("Triangle: {0}", triangle);


            Console.ReadKey();
        }

    }

}

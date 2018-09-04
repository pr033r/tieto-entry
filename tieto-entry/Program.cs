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

            //squareObjects.read(Path.Combine(appDataDirectory.path, "test2.xml"));
            //squareObjects.write(Path.Combine(appDataDirectory.path, "test2.xml"), new _2dObjects(new double[] { 1, 2, 3 }));

            List<_2dObject> squareObjects = new List<_2dObject>();

            squareObjects.Add(new Square(5.6));
            squareObjects.Add(new Square(400.658));
            squareObjects.Add(new Square(151.2));
            squareObjects.Add(new Rectangle(40.3, 5));
            squareObjects.Add(new Rectangle(20.8, 50.7));
            squareObjects.Add(new Rectangle(3.8, 60.981));
            squareObjects.Add(new Triangle(1, 1, 1.41));
            squareObjects.Add(new Triangle(20, 40, 44.72456));
            squareObjects.Add(new Triangle(5, 3, 7));

            Console.WriteLine(_2dObjectCoordinator.getTrianglesPeriphery(squareObjects, max: true));

            _2dObject rectangle = new Rectangle(); // TODO do predka posilat message

            foreach(var item in _2dObjectCoordinator.getPythagoreanTriangles(squareObjects)) {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

    }

}

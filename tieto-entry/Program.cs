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
            squareObjects.read(Path.Combine(appDataDirectory.path, "test.xml"), 2);

            Console.WriteLine(squareObjects);

            Console.ReadKey();
        }

    }

}

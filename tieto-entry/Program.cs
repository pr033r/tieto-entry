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
            Logger log = new Logger(appDataDirectory.path);

            StorageFactory storageFactory = new StorageFactory();

            XMLManager xmlManager = storageFactory.getXMLManager();
            xmlManager.read(Path.Combine(appDataDirectory.path, "test.xml"));
            
            Console.ReadKey();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class StorageFactory {

        public IDataProvider<_2dObject> getXMLManager() {
            return new XML2DObjectsManager();
        }

        public IDataProvider<_2dObject> getDBManager() {
            return new DB2DObjectManager();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class StorageFactory {

        public XMLManager getXMLManager() {
            return new XML2DObjectsManager();
        }

    }

}

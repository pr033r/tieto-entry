using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    interface I2dObject<T> {

        List<T> read(IDataProvider<T> dataProvider, string pathToFile = null);
        void write(IDataProvider<T> dataProvider, List<T> squareObjects, string pathToFile = null);

    }

}

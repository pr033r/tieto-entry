using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    interface I2dObject {

        void read(string pathToFile);
        void write(string pathToFile, _2dObject squareObject);

    }

}

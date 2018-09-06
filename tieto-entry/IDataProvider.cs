using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    public interface IDataProvider<T> {

        List<T> read(string pathToFile);
        void write(string pathToFile, List<T> objectToWrite);

    }

}

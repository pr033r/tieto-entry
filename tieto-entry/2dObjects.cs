using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class _2dObjects : I2dObject {

        public double Periphery { get; set; }
        public double[] Edges { get; set; }

        public _2dObjects(double[] edges = null) {
            this.Edges = edges;
        }

        public void read() {
            // TODO
        }

        public void write() {
            // TODO
        }

    }

}

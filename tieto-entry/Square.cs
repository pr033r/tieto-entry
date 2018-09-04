using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class Square : _2dObjects {

        private _2dObjects squareSurface;
        private double sideA;

        public Square(double sideA = 1) {
            double[] edges = Enumerable.Repeat(sideA, 4).ToArray();
            squareSurface = new _2dObjects(edges);
            this.sideA = sideA;
        }

        public double surface() {
            return Math.Pow(sideA, 2);
        }

        public override string ToString() {
            string square = string.Format("Side A: {0}, ", sideA);
            square += string.Format("Periphery: {0}, ", squareSurface.Periphery);
            square += string.Format("Surface: {0}", surface());
            return square;
        }
    }

}

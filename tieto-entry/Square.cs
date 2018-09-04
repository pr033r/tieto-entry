using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class Square : _2dObject {

        private double sideA;

        public Square(double sideA = 1) {
            double[] edges = Enumerable.Repeat(sideA, 4).ToArray();
            this.sideA = sideA;
            base.Edges = edges;
        }

        public double surface() {
            return Math.Pow(sideA, 2);
        }

        public override string ToString() {
            string square = string.Format("Side A: {0}, ", sideA);
            square += string.Format("Periphery: {0}, ", base.Periphery);
            square += string.Format("Surface: {0}", surface());
            return square;
        }
    }

}

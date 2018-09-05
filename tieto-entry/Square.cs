using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    public class Square : _2dObject {

        public Square(double sideA = 1) {
            sideA = Math.Round(sideA, 2);
            double[] edges = Enumerable.Repeat(sideA, 4).ToArray();
            base.Edges = edges;
        }

        public double surface() {
            return Math.Pow(Edges[0], 2);
        }

        public override string ToString() {
            string square = string.Format("Side A: {0}, ", Edges[0]);
            square += string.Format("Periphery: {0}, ", Periphery);
            square += string.Format("Surface: {0}", surface());
            return square;
        }
    }

}

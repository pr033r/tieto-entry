using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    public class InvalidTriangleSidesException : Exception {
        public InvalidTriangleSidesException(string message)
            : base(message) { }
    }

    public class Triangle : _2dObject {

        public Triangle(double sideA = 1, double sideB = 1, double sideC = 1) {
            sideA = Math.Round(sideA, 2);
            sideB = Math.Round(sideB, 2);
            sideC = Math.Round(sideC, 2);
            double[] edges = { sideA, sideB, sideC };
            base.Edges = edges;

            try {
                isTriangleValid();
            } catch (InvalidTriangleSidesException e) {
                Log.writeError(e.ToString());
            }
        }

        public double surface() {
            double s = (Edges[0] + Edges[1] + Edges[2]) / 2;
            double heronFormula = Math.Sqrt(s * (s - Edges[0]) * (s - Edges[1]) * (s - Edges[2]));
            return Math.Round(heronFormula, 2);
        }

        public bool isPythagorean() {
            double ordinate = Math.Round(Math.Sqrt(Math.Pow(Edges[0], 2) + Math.Pow(Edges[1], 2)), 2);
            return ordinate == Edges[2];
        }

        public override string ToString() {
            string rectangle = string.Format("Side A: {0}, ", Edges[0]);
            rectangle += string.Format("Side B: {0}, ", Edges[1]);
            rectangle += string.Format("Side C: {0}, ", Edges[2]);
            rectangle += string.Format("Periphery: {0}, ", Periphery);
            rectangle += string.Format("Surface: {0}, ", surface());
            rectangle += string.Format("isPythagorean: {0}", isPythagorean());
            return rectangle;
        }

        public bool isTriangleValid() {
            double sideA = Edges[0];
            double sideB = Edges[1];
            double sideC = Edges[2];
            if (sideA + sideB > sideC &&
                sideB + sideC > sideA &&
                sideC + sideA > sideB) {
                return true;
            } else {
                throw new InvalidTriangleSidesException("Invalid triangle sides.");
            }
        }

    }

}

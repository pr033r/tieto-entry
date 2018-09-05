using System;

namespace tieto_entry {

    public class Rectangle : _2dObject {

        public Rectangle(double sideA = 1, double sideB = 1) {
            sideA = Math.Round(sideA, 2);
            sideB = Math.Round(sideB, 2);
            double[] edges = { sideA, sideB, sideA, sideB };
            base.Edges = edges;
        }

        public double surface() {
            return Edges[0] * Edges[1];
        }

        public override string ToString() {
            string rectangle = string.Format("Side A: {0}, ", Edges[0]);
            rectangle += string.Format("Side B: {0}, ", Edges[1]);
            rectangle += string.Format("Periphery: {0}, ", Periphery);
            rectangle += string.Format("Surface: {0}", surface());
            return rectangle;
        }
    }

}

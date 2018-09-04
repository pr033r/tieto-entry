using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class Rectangle : _2dObject {

        private double sideA, sideB;

        public Rectangle(double sideA = 1, double sideB = 1) {
            double[] edges = { sideA, sideB, sideA, sideB };
            this.sideA = sideA;
            this.sideB = sideB;
            base.Edges = edges;
        }

        public double surface() {
            return sideA * sideB;
        }

        public override string ToString() {
            string rectangle = string.Format("Side A: {0}, ", sideA);
            rectangle += string.Format("Side B: {0}, ", sideB);
            rectangle += string.Format("Periphery: {0}, ", base.Periphery);
            rectangle += string.Format("Surface: {0}", surface());
            return rectangle;
        }
    }

}

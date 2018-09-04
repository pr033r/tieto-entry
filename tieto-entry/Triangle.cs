﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class InvalidTriangleSidesException : Exception {
        public InvalidTriangleSidesException(string message) 
            :base(message) { }
    }

    class Triangle : _2dObject {

        private double sideA, sideB, sideC;

        public Triangle(double sideA = 1, double sideB = 1, double sideC = 1) {
            double[] edges = { sideA, sideB, sideC };
            this.sideA = Math.Round(sideA, 2);
            this.sideB = Math.Round(sideB, 2);
            this.sideC = Math.Round(sideC, 2);

            try {
                isTriangleValid();
            } catch (InvalidTriangleSidesException e) {
                Log.writeError(e.ToString());
            }
            base.Edges = edges;
        }

        public double surface() {
            double s = (sideA + sideB + sideC) / 2;
            double heronFormula = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
            return Math.Round(heronFormula, 2);
        }

        public bool isPythagorean() {
            double ordinate = Math.Round(Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2)), 2);
            return ordinate == sideC;
        }

        public override string ToString() {
            string rectangle = string.Format("Side A: {0}, ", sideA);
            rectangle += string.Format("Side B: {0}, ", sideB);
            rectangle += string.Format("Side C: {0}, ", sideC);
            rectangle += string.Format("Periphery: {0}, ", base.Periphery);
            rectangle += string.Format("Surface: {0}, ", surface());
            rectangle += string.Format("isPythagorean: {0}", isPythagorean());
            return rectangle;
        }

        private bool isTriangleValid() {
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

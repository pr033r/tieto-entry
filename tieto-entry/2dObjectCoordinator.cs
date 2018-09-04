using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    static class _2dObjectCoordinator {

        public static bool isTriangle(_2dObject squareObject) {
            return squareObject.Edges.Count() == 3 ? true : false;
        }

        public static bool isSquare(_2dObject squareObject) {
            double firstItem = squareObject.Edges[0];
            return squareObject.Edges.All(x => double.Equals(x, firstItem));
        }

        public static bool isRectangle(_2dObject squareObject) {
            if (squareObject.Edges.Count() != 4) return false;
            if (_2dObjectCoordinator.isSquare(squareObject)) return false;

            bool sidesUpDown = squareObject.Edges[0] == squareObject.Edges[2];
            bool sidesLeftRight = squareObject.Edges[1] == squareObject.Edges[3];
            return sidesUpDown && sidesLeftRight;
        }

        public static _2dObject getTrianglesPeriphery(List<_2dObject> squareObjects, bool min = false, bool max = false) {
            List<_2dObject> filteredTriangleObjects = squareObjects.FindAll(x => x is Triangle);
            return getPeripherySquareObject(min, max, filteredTriangleObjects);
        }

        public static _2dObject getSquarePeriphery(List<_2dObject> squareObjects, bool min = false, bool max = false) {
            List<_2dObject> filteredSquareObjects = squareObjects.FindAll(x => x is Square);
            return getPeripherySquareObject(min, max, filteredSquareObjects);
        }

        public static _2dObject getRectanglePeriphery(List<_2dObject> squareObjects, bool min = false, bool max = false) {
            List<_2dObject> filteredRectangleObjects = squareObjects.FindAll(x => x is Rectangle);
            return getPeripherySquareObject(min, max, filteredRectangleObjects);
        }

        public static List<Triangle> getPythagoreanTriangles(List<_2dObject> squareObjects) {
            List<_2dObject> filteredRectangleObjects = squareObjects.FindAll(x => x is Triangle);
            List<Triangle> rectanglesToBeReturned = new List<Triangle>();

            foreach(Triangle rectangle in filteredRectangleObjects) {
                if (rectangle.isPythagorean()) {
                    rectanglesToBeReturned.Add(rectangle);
                }
            }

            return rectanglesToBeReturned;
        }

        private static _2dObject getPeripherySquareObject(bool min, bool max, List<_2dObject> triangleObjects) {
            if (min) {
                return triangleObjects.OrderBy(x => x.Periphery).FirstOrDefault();
            }
            else if (max) {
                return triangleObjects.OrderBy(x => x.Periphery).LastOrDefault();
            }
            else {
                return null;
            }
        }
    }

}

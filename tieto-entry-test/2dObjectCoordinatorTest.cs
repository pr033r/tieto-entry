using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using tieto_entry;

namespace tieto_entry_test {

    [TestClass]
    public class _2dObjectCoordinatorTest {

        private List<_2dObject> squareObjects = new List<_2dObject>();

        [TestInitialize]
        public void Initialize() {
            squareObjects.Add(new Square(5.6));
            squareObjects.Add(new Square(400.658));
            squareObjects.Add(new Square(151.2));
            squareObjects.Add(new Rectangle(40.3, 5));
            squareObjects.Add(new Rectangle(20.8, 50.7));
            squareObjects.Add(new Rectangle(3.8, 60.981));
            squareObjects.Add(new Triangle(1, 1, 1.41));
            squareObjects.Add(new Triangle(20, 40, 44.72));
            squareObjects.Add(new Triangle(5, 3, 7));
        }

        [TestMethod]
        public void isTriangle() {
            _2dObject squareObjectToBeFalseVariant1 = new _2dObject(new double[] { 1, 2 });
            _2dObject squareObjectToBeFalseVariant2 = new _2dObject(new double[] { 5, 5, 10 });
            _2dObject squareObjectToBeFalseVariant3 = new _2dObject(new double[] { 5, 5, 10, 15, 20 });
            _2dObject squareObjectToBeTrue = new _2dObject(new double[] { 1, 1, 1.41 });
            Assert.IsFalse(_2dObjectCoordinator.isTriangle(squareObjectToBeFalseVariant1));
            Assert.IsFalse(_2dObjectCoordinator.isTriangle(squareObjectToBeFalseVariant2));
            Assert.IsFalse(_2dObjectCoordinator.isTriangle(squareObjectToBeFalseVariant3));
            Assert.IsTrue(_2dObjectCoordinator.isTriangle(squareObjectToBeTrue));
        }

        [TestMethod]
        public void isSquare() {
            _2dObject squareObject = new _2dObject();
            Assert.IsFalse(_2dObjectCoordinator.isSquare(squareObject));
            squareObject.Edges = new double[] { 1, 1, 2, 1, 5, 5 };
            Assert.IsFalse(_2dObjectCoordinator.isSquare(squareObject));
            squareObject.Edges = new double[] { 1, 1, 2 };
            Assert.IsFalse(_2dObjectCoordinator.isSquare(squareObject));
            squareObject.Edges = new double[] { 1, 1, 2, 1 };
            Assert.IsFalse(_2dObjectCoordinator.isSquare(squareObject));
            squareObject.Edges = new double[] { 1, 1, 1, 1 };
            Assert.IsTrue(_2dObjectCoordinator.isSquare(squareObject));
        }

        [TestMethod]
        public void isRectangle() {
            _2dObject squareObjectRectangle = new _2dObject();
            Assert.IsFalse(_2dObjectCoordinator.isRectangle(squareObjectRectangle));
            squareObjectRectangle.Edges = new double[] { 1, 1, 2, 1, 5, 5 };
            Assert.IsFalse(_2dObjectCoordinator.isRectangle(squareObjectRectangle));
            squareObjectRectangle.Edges = new double[] { 1, 1, 2 };
            Assert.IsFalse(_2dObjectCoordinator.isRectangle(squareObjectRectangle));
            squareObjectRectangle.Edges = new double[] { 1, 1, 2, 1 };
            Assert.IsFalse(_2dObjectCoordinator.isRectangle(squareObjectRectangle));
            squareObjectRectangle.Edges = new double[] { 1, 2, 1, 2 };
            Assert.IsTrue(_2dObjectCoordinator.isRectangle(squareObjectRectangle));
        }

        [TestMethod]
        public void getTrianglesPeriphery() {
            _2dObject expectedTriangle = new Triangle(20, 40, 44.72);
            _2dObject returnedTriangle = _2dObjectCoordinator.getTrianglesPeriphery(squareObjects, max: true);
            CollectionAssert.AreEqual(expectedTriangle.Edges, returnedTriangle.Edges);
            Assert.AreEqual(expectedTriangle.Periphery, returnedTriangle.Periphery);

            expectedTriangle = new Triangle(1, 1, 1.41);
            returnedTriangle = _2dObjectCoordinator.getTrianglesPeriphery(squareObjects, min: true);
            CollectionAssert.AreEqual(expectedTriangle.Edges, returnedTriangle.Edges);
            Assert.AreEqual(expectedTriangle.Periphery, returnedTriangle.Periphery);
        }

        [TestMethod]
        public void getSquarePeriphery() {
            _2dObject expectedSquare = new Square(400.658);
            _2dObject returnedSquare = _2dObjectCoordinator.getSquarePeriphery(squareObjects, max: true);
            CollectionAssert.AreEqual(expectedSquare.Edges, returnedSquare.Edges);
            Assert.AreEqual(expectedSquare.Periphery, returnedSquare.Periphery);

            expectedSquare = new Square(5.6);
            returnedSquare = _2dObjectCoordinator.getSquarePeriphery(squareObjects, min: true);
            CollectionAssert.AreEqual(expectedSquare.Edges, returnedSquare.Edges);
            Assert.AreEqual(expectedSquare.Periphery, returnedSquare.Periphery);
        }

        [TestMethod]
        public void getRectanglePeriphery() {
            _2dObject expectedRectangle = new Rectangle(20.8, 50.7);
            _2dObject returnedRectangle = _2dObjectCoordinator.getRectanglePeriphery(squareObjects, max: true);
            CollectionAssert.AreEqual(expectedRectangle.Edges, returnedRectangle.Edges);
            Assert.AreEqual(expectedRectangle.Periphery, returnedRectangle.Periphery);

            expectedRectangle = new Rectangle(40.3, 5);
            returnedRectangle = _2dObjectCoordinator.getRectanglePeriphery(squareObjects, min: true);
            CollectionAssert.AreEqual(expectedRectangle.Edges, returnedRectangle.Edges);
            Assert.AreEqual(expectedRectangle.Periphery, returnedRectangle.Periphery);
        }

        [TestMethod]
        public void getPythagoreanTriangles() {
            List<_2dObject> expetedTriangles = new List<_2dObject>();
            List<Triangle> returnedTriangles = _2dObjectCoordinator.getPythagoreanTriangles(squareObjects);

            expetedTriangles.Add(new Triangle(1, 1, 1.41));
            expetedTriangles.Add(new Triangle(20, 40, 44.72));

            CollectionAssert.AreEqual(expetedTriangles[0].Edges, returnedTriangles[0].Edges);
            CollectionAssert.AreEqual(expetedTriangles[1].Edges, returnedTriangles[1].Edges);
            Assert.AreEqual(expetedTriangles[0].Periphery, returnedTriangles[0].Periphery);
            Assert.AreEqual(expetedTriangles[1].Periphery, returnedTriangles[1].Periphery);
        }

    }

}

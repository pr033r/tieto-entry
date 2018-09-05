using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tieto_entry;

namespace tieto_entry_test {

    [TestClass]
    public class TriangleTest {

        private Triangle triangle;

        [TestInitialize]
        public void Initialize() {
            triangle = new Triangle();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTriangleSidesException),
            "Triangle edges sizes must be valid")]
        public void generalInvalidTriangleEdgeSizeException() {
            triangle.Edges = new double[] { 1, 1, 5 };
            triangle.isTriangleValid();
        }

        [TestMethod]
        public void surface() {
            Assert.AreEqual(0.43, triangle.surface());
            Assert.AreEqual(3, triangle.Periphery);
            triangle.Edges = new double[] { 10, 10, 5 };
            Assert.AreEqual(24.21, triangle.surface());
            Assert.AreEqual(25, triangle.Periphery);
        }

        [TestMethod]
        public void isTrianglePythagorean() {
            Assert.IsFalse(triangle.isPythagorean());
            triangle.Edges = new double[] { 1, 1, 1.41 };
            Assert.IsTrue(triangle.isPythagorean());
        }

        [TestCleanup]
        public void cleanUp() {
        }

    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tieto_entry;

namespace tieto_entry_test {

    [TestClass]
    public class SquareTest {

        private Square square;

        [TestInitialize]
        public void Initialize() {
            square = new Square();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEdgeSizeException),
            "User cannot set zero or lower value into edge array")]
        public void generalInvalidEdgeSizeException() {
            square.Edges = new double[] { 0, 1, -100, 1 };
            square.chceckEdgesValidity();
        }

        [TestMethod]
        public void surface() {
            Assert.AreEqual(1, square.surface());
            Assert.AreEqual(4, square.Periphery);
            square.Edges = new double[] { 1.2, 1.2, 1.2, 1.2 };
            Assert.AreEqual(1.44, square.surface());
            Assert.AreEqual(4.8, square.Periphery);
        }

        [TestCleanup]
        public void cleanUp() {
        }
    }

}

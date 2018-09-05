using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tieto_entry;

namespace tieto_entry_test {
    
    [TestClass]
    public class RectangleTest {

        private Rectangle rectangle;

        [TestInitialize]
        public void Initialize() {
            rectangle = new Rectangle();
        }

        [TestMethod]
        public void surface() {
            Assert.AreEqual(1, rectangle.surface());
            Assert.AreEqual(4, rectangle.Periphery);
            rectangle.Edges = new double[] { 1.2, 500.12, 1.2, 500.12 };
            Assert.AreEqual(600.144, rectangle.surface());
            Assert.AreEqual(1002.64, rectangle.Periphery);
        }

        [TestCleanup]
        public void cleanUp() {
        }

    }
}

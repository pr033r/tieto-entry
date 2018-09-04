using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class InvalidEdgeSizeException : Exception {
        public InvalidEdgeSizeException(string message)
            :base(message) { }
    }

    class _2dObjects : I2dObject {

        private StorageFactory storageFactory;

        public double Periphery { get; set; }
        public double[] Edges { get; set; }

        public _2dObjects(double[] edges = null) {
            Edges = edges == null ? new double[] { 1 } : edges;
            storageFactory = new StorageFactory();
            calculatePeriphery();
        }

        public void read(string pathToFile, int indexOfSquareObject) {
            XMLManager xmlManager = storageFactory.getXMLManager();
            List<_2dObjects> loadedSquareObjects = xmlManager.read(pathToFile);
            try {
                Periphery = loadedSquareObjects[indexOfSquareObject].Periphery;
                Edges = loadedSquareObjects[indexOfSquareObject].Edges;
                chceckEdgesValidity();
            } catch (ArgumentOutOfRangeException e) {
                Log.writeError(e.ToString());
            } catch (InvalidEdgeSizeException e) {
                Log.writeError(e.ToString());
            }
        }

        public void write() {
            // TODO
        }

        public override string ToString() {
            string squareObject = null;
            squareObject += string.Format("Edges: {0}\n", string.Join(", ", Edges));
            squareObject += string.Format("Periphery: {0}\n", Periphery);
            return squareObject;
        }

        private void calculatePeriphery() {
            try {
                chceckEdgesValidity();
                foreach (var edge in Edges) {
                    Periphery += edge;
                }
            } catch (InvalidEdgeSizeException e) {
                Log.writeError(e.ToString());
            }
        }

        private void chceckEdgesValidity() {
            foreach (var edge in Edges) {
                if (edge <= 0) {
                    throw new InvalidEdgeSizeException("Size of edge must be greater than zero.");
                }
            }
        }

    }

}

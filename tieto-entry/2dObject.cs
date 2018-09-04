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

    class _2dObject : I2dObject {

        private StorageFactory storageFactory;
        private double[] edges;
        public double Periphery { get; set; }

        public double[] Edges {
            get => edges;
            set {
                edges = value;
                calculatePeriphery();
            }
        }

        public _2dObject(double[] edges = null) {
            Edges = edges == null ? new double[] { 1 } : edges;
            storageFactory = new StorageFactory();
            calculatePeriphery();
        }

        public void read(string pathToFile) {
            XMLManager xmlManager = storageFactory.getXMLManager();
            _2dObject loadedSquareObject = xmlManager.read(pathToFile);
            Periphery = loadedSquareObject.Periphery;
            Edges = loadedSquareObject.Edges;
            try {
                chceckEdgesValidity();
            } catch (InvalidEdgeSizeException e) {
                Log.writeError(e.ToString());
            }
        }

        public void write(string pathToFile, _2dObject squareObject) {
            XMLManager xmlManager = storageFactory.getXMLManager();
            Periphery = squareObject.Periphery;
            Edges = squareObject.Edges;
            try {
                chceckEdgesValidity();
                xmlManager.write(pathToFile, squareObject);
            }
            catch (InvalidEdgeSizeException e) {
                Log.writeError(e.ToString());
            }
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
                Periphery = 0;
                foreach (var edge in Edges) {
                    Periphery += edge;
                }
            } catch (InvalidEdgeSizeException e) {
                Log.writeError(e.ToString());
            } catch (Exception e) {
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

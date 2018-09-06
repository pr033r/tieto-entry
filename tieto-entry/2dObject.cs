using System;
using System.Collections.Generic;
using System.Linq;

namespace tieto_entry {

    public class InvalidEdgeSizeException : Exception {
        public InvalidEdgeSizeException(string message)
            :base(message) { }
    }

    public class _2dObject : I2dObject<_2dObject> {

        private StorageFactory storageFactory;
        private double[] edges;

        public double Periphery { get; set; }

        public double[] Edges {
            get => edges;
            set {
                edges = value;
                edges = edges.Select(x => Math.Round(x, 2)).ToArray();
                calculatePeriphery();
            }
        }

        public _2dObject(double[] edges = null) {
            Edges = edges == null ? new double[] { 1 } : edges;
            storageFactory = new StorageFactory();
            calculatePeriphery();
        }

        public List<_2dObject> read(IDataProvider<_2dObject> dataProvider, string pathToFile) {
            List<_2dObject> loadedSquareObjects = dataProvider.read(pathToFile);
            calculatePeripheriesAndCheckEdgesValidity(loadedSquareObjects);

            Log.writeInfo(string.Format("File {0} was loaded.", pathToFile));
            return loadedSquareObjects;
        }

        public void write(IDataProvider<_2dObject> dataProvider, List<_2dObject> squareObjectsToBeWrite, string pathToFile) {
            calculatePeripheriesAndCheckEdgesValidity(squareObjectsToBeWrite);
            dataProvider.write(pathToFile, squareObjectsToBeWrite);
            Log.writeInfo(string.Format("Data has been written to {0} file.", pathToFile));
        }

        public override string ToString() {
            string squareObject = null;
            squareObject += string.Format("Edges: {0}\n", string.Join(", ", Edges));
            squareObject += string.Format("Periphery: {0}\n", Periphery);
            return squareObject;
        }

        public void chceckEdgesValidity() {
            foreach (var edge in Edges) {
                if (edge <= 0) {
                    throw new InvalidEdgeSizeException("Size of edge must be greater than zero.");
                }
            }
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

        private static void calculatePeripheriesAndCheckEdgesValidity(List<_2dObject> squareObjectsToBeWrite) {
            foreach (var squareObject in squareObjectsToBeWrite) {
                try {
                    squareObject.calculatePeriphery();
                } catch (InvalidEdgeSizeException e) {
                    Log.writeError(e.ToString());
                }
            }
        }
    }

}

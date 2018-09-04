using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    interface XMLManager {

        List<_2dObjects> read(string pathToFile);
        void write(string pathToFile, List<_2dObjects> squareObjects);

    }

    class XML2DObjectsManager : XMLManager {

        private List<_2dObjects> squareObjects = new List<_2dObjects>();

        public List<_2dObjects> read(string pathToFile) {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathToFile);

            XmlNode root = doc.DocumentElement;
            fetchSquareObjectElements(root);
            return squareObjects;
        }

        public void write(string pathToFile, List<_2dObjects> squareObjects) {

        }

        public override string ToString() {
            string squareObjects = null;
            foreach(var squareObject in this.squareObjects) {
                squareObjects += string.Format("Edges: {0}\n", string.Join(", ", squareObject.Edges));
                squareObjects += string.Format("Periphery: {0}\n", squareObject.Periphery);
            }
            return squareObjects;
        }

        private void fetchSquareObjectElements(XmlNode root) {
            foreach (XmlNode node in root.ChildNodes) {

                XmlElement squareObjectElement = (XmlElement)node;
                _2dObjects squareObject = new _2dObjects();

                squareObject.Edges = fetchEdgesFromXmlNode(squareObjectElement);
                squareObject.Periphery = fetchPeripheryFromXmlNode(squareObjectElement); ;

                squareObjects.Add(squareObject);
            }
        }

        private static double fetchPeripheryFromXmlNode(XmlElement squareObjectElement) {
            double periphery = 0.0;
            double.TryParse(squareObjectElement.GetElementsByTagName("periphery")[0].InnerText, out periphery);
            return periphery;
        }

        private static double[] fetchEdgesFromXmlNode(XmlElement squareObjectElement) {
            XmlNodeList edges = squareObjectElement.GetElementsByTagName("edge");
            double[] edgesArray = new double[edges.Count];
            for (int i = 0; i < edges.Count; i++) {
                double.TryParse(edges[i].InnerText, out edgesArray[i]);
            }

            return edgesArray;
        }
    }

}

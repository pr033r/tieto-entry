using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class XML2DObjectsManager : IDataProvider<_2dObject> {

        private List<_2dObject> squareObjects = new List<_2dObject>();

        public List<_2dObject> read(string pathToFile = null) {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathToFile);

            XmlNode root = doc.DocumentElement;
            fetchSquareObjectElements(root);
            return squareObjects;
        }

        public void write(List<_2dObject> squareObjects, string pathToFile = null) {
            XmlDocument document = new XmlDocument();
            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = document.CreateElement("squareObject");

            document.AppendChild(declaration);
            foreach(var squareObject in squareObjects) {
                writeSquareObject(squareObject, document, root);
            }

            document.AppendChild(root);
            document.Save(pathToFile);
        }

        private static void writeSquareObject(_2dObject squareObject, XmlDocument document, XmlElement root) {
            XmlElement objectElement = document.CreateElement("object");

            writeEdges(squareObject, document, objectElement);
            writePeriphery(squareObject, document, objectElement);

            root.AppendChild(objectElement);
        }

        private static void writeEdges(_2dObject squareObject, XmlDocument document, XmlElement objectElement) {
            foreach (var node in squareObject.Edges) {
                XmlElement edge = document.CreateElement("edge");
                edge.InnerText = node.ToString();
                objectElement.AppendChild(edge);
            }
        }

        private static void writePeriphery(_2dObject squareObject, XmlDocument document, XmlElement objectElement) {
            XmlElement periphery = document.CreateElement("periphery");
            periphery.InnerText = squareObject.Periphery.ToString();
            objectElement.AppendChild(periphery);
        }

        private void fetchSquareObjectElements(XmlNode root) {
            foreach(XmlNode node in root.ChildNodes) {
                _2dObject squareObject = new _2dObject();
                XmlElement squareObjectElement = (XmlElement)node;

                squareObject.Edges = fetchEdgesFromXmlNode(squareObjectElement);
                squareObject.Periphery = fetchPeripheryFromXmlNode(squareObjectElement);
                createTypeOfDescendant(squareObject);
            }
        }

        private static double[] fetchEdgesFromXmlNode(XmlElement squareObjectElement) {
            XmlNodeList edges = squareObjectElement.GetElementsByTagName("edge");
            double[] edgesArray = new double[edges.Count];
            for (int i = 0; i < edges.Count; i++) {
                double.TryParse(edges[i].InnerText, out edgesArray[i]);
            }

            return edgesArray;
        }

        private static double fetchPeripheryFromXmlNode(XmlElement squareObjectElement) {
            double periphery = 0.0;
            double.TryParse(squareObjectElement.GetElementsByTagName("periphery")[0].InnerText, out periphery);
            return periphery;
        }

        private void createTypeOfDescendant(_2dObject squareObject) {
            if (_2dObjectCoordinator.isRectangle(squareObject)) {
                squareObjects.Add(new Rectangle(squareObject.Edges[0], squareObject.Edges[1]));
            }
            if (_2dObjectCoordinator.isSquare(squareObject)) {
                squareObjects.Add(new Square(squareObject.Edges[0]));
            }
            if (_2dObjectCoordinator.isTriangle(squareObject)) {
                squareObjects.Add(new Triangle(squareObject.Edges[0], squareObject.Edges[1], squareObject.Edges[2]));
            }
        }
    }

}

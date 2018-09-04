using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    interface XMLManager {

        _2dObject read(string pathToFile);
        void write(string pathToFile, _2dObject squareObjects);

    }

    class XML2DObjectsManager : XMLManager {

        private _2dObject squareObject = new _2dObject();

        public _2dObject read(string pathToFile) {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathToFile);

            XmlNode root = doc.DocumentElement;
            fetchSquareObjectElements(root);
            return squareObject;
        }

        public void write(string pathToFile, _2dObject squareObject) {
            XmlDocument document = new XmlDocument();
            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = document.CreateElement("squareObject");

            document.AppendChild(declaration);
            writeSquareObject(squareObject, document, root);

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

            XmlElement squareObjectElement = (XmlElement)root.ChildNodes[0];
            _2dObject squareObject = new _2dObject();

            squareObject.Edges = fetchEdgesFromXmlNode(squareObjectElement);
            squareObject.Periphery = fetchPeripheryFromXmlNode(squareObjectElement); ;

            this.squareObject = squareObject;
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
    }

}

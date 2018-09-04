using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    interface XMLManager {

        _2dObjects read(string pathToFile);
        void write(string pathToFile, _2dObjects squareObjects);

    }

    class XML2DObjectsManager : XMLManager {

        private _2dObjects squareObject = new _2dObjects();

        public _2dObjects read(string pathToFile) {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathToFile);

            XmlNode root = doc.DocumentElement;
            fetchSquareObjectElements(root);
            return squareObject;
        }

        public void write(string pathToFile, _2dObjects squareObject) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = doc.CreateElement("squareObject");

            doc.AppendChild(declaration);
            writeSquareObject(squareObject, doc, root);

            doc.AppendChild(root);
            doc.Save(pathToFile);
        }

        private static void writeSquareObject(_2dObjects squareObject, XmlDocument doc, XmlElement root) {
            XmlElement objectElement = doc.CreateElement("object");

            writeEdges(squareObject, doc, objectElement);
            writePeriphery(squareObject, doc, objectElement);

            root.AppendChild(objectElement);
        }

        private static void writeEdges(_2dObjects squareObject, XmlDocument doc, XmlElement objectElement) {
            foreach (var node in squareObject.Edges) {
                XmlElement edge = doc.CreateElement("edge");
                edge.InnerText = node.ToString();
                objectElement.AppendChild(edge);
            }
        }

        private static void writePeriphery(_2dObjects squareObject, XmlDocument doc, XmlElement objectElement) {
            XmlElement periphery = doc.CreateElement("periphery");
            periphery.InnerText = squareObject.Periphery.ToString();
            objectElement.AppendChild(periphery);
        }

        private void fetchSquareObjectElements(XmlNode root) {

            XmlElement squareObjectElement = (XmlElement)root.ChildNodes[0];
            _2dObjects squareObject = new _2dObjects();

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

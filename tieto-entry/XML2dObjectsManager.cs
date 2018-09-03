using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    interface XMLManager {

        void read(string pathToFile);
        void write(string pathToFile);

    }

    class XML2DObjectsManager : XMLManager {

        private List<_2dObjects> squareObjects = new List<_2dObjects>();

        public XML2DObjectsManager() {
        }

        public void read(string pathToFile) {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathToFile);

            XmlNode root = doc.DocumentElement;

            foreach (XmlNode node in root.ChildNodes) {

                XmlElement squareObjectElement = (XmlElement)node;
                _2dObjects squareObject = new _2dObjects();

                XmlNodeList edges = squareObjectElement.GetElementsByTagName("edge");

                //userData.age = int.Parse(user.GetAttribute("vek"));
                //userData.name = user.GetElementsByTagName("jmeno")[0].InnerText;
                //string hovno = user.GetElementsByTagName("registrovan")[0].InnerText;
                //userData.birth = DateTime.ParseExact(user.GetElementsByTagName("registrovan")[0].InnerText, "dd.MM.yyyy", null);

                squareObjects.Add(squareObject);

            }
        }

        public void write(string pathToFile) {

        }
    }

}

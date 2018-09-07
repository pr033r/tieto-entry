using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class DB2DObjectManager : IDataProvider<_2dObject> {

        private DataClassesDataContext db = new DataClassesDataContext();
        private List<_2dObject> squareObjects = new List<_2dObject>();

        public List<_2dObject> read(string pathToFile = null) {
            var objectsIds = from i in db.Objects select i.id;

            foreach (var objId in objectsIds) {
                double[] edges = getEdgesArray(objId);
                createTypeOfDescendant(new _2dObject(edges));
            }
            return squareObjects;
        }

        public void write(List<_2dObject> objectsToWrite, string pathToFile = null) {

            foreach(var squareObject in objectsToWrite) {
                db.Objects.InsertOnSubmit(new Object { periphery = squareObject.Periphery });
                try {
                    db.SubmitChanges();
                    writeEdges(squareObject);
                } catch (Exception e) {
                    Log.writeError(e.ToString());
                }
            }
        }

        private void writeEdges(_2dObject squareObject) {

            foreach (var edge in squareObject.Edges) {
                db.Edges.InsertOnSubmit(new Edge { edge1 = edge, objectId = getLastId() });

                try {
                    db.SubmitChanges();
                } catch (Exception e) {
                    Log.writeError(e.ToString());
                }
            }
        }

        private int getLastId() {
            var lastId = from i in db.Objects
                         group i by i.id into id
                         select new { id.Key };

            int lastIdNumber = lastId.OrderByDescending(x => x.Key).First().Key;
            return lastIdNumber;
        }

        private double[] getEdgesArray(int objId) {
            var edgesByObjectId = from i in db.Edges
                                  where (i.objectId == objId)
                                  select i;
            return fillEdgesArray(edgesByObjectId);
        }

        private static double[] fillEdgesArray(IQueryable<Edge> edgesByObjectId) {
            double[] edges = new double[edgesByObjectId.Count()];

            int edgesIndex = 0;
            foreach (var edge in edgesByObjectId) {
                edges[edgesIndex] = edge.edge1;
                edgesIndex++;
            }
            return edges;
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

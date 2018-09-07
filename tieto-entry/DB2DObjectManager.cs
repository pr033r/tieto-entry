using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieto_entry {

    class DB2DObjectManager : IDataProvider<_2dObject> {

        private DataClassesDataContext db;

        public DB2DObjectManager() {
            db = new DataClassesDataContext();
        }

        public List<_2dObject> read(string pathToFile = null) {
            throw new NotImplementedException();
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
    }

}

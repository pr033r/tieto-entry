using System;
using System.IO;

namespace tieto_entry {

    class Logger {

        private string fileName = "logs.log";
        private string path = null;
        private string fullPath = null;

        public Logger(string path) {
            this.path = path;
            fullPath = Path.Combine(path, fileName);
        }

        public void writeLog(string message) {
            writeToFile(string.Format("LOG: {0}", message));
        }

        public void writeInfo(string message) {
            writeToFile(string.Format("INFO: {0}", message));
        }

        public void writeError(string message) {
            writeToFile(string.Format("ERR: {0}", message));
        }

        private void writeToFile(string text) {
            try {
                using (StreamWriter writer = new StreamWriter(fullPath, fileMethod())) {
                    writer.WriteLine(text);
                    writer.Flush();
                }
            }
            catch (Exception e) {
                Console.WriteLine("Err: {0}", e.Message);
            }
        }

        private bool fileMethod() {
            return File.Exists(fullPath) ? true : false;
        }

    }
}

using System;
using System.IO;

namespace tieto_entry {

    static class Log {

        public static string fileName = "logs.log";
        public static string fullPath = null;

        public static void init(string path) {
            fullPath = Path.Combine(path, fileName);
        }

        public static void writeWarn(string message) {
            writeToFile(string.Format("WARN: {0}", message));
        }

        public static void writeInfo(string message) {
            writeToFile(string.Format("INFO: {0}", message));
        }

        public static void writeError(string message) {
            writeToFile(string.Format("ERR: {0}", message));
            Console.WriteLine("An error has occured. See {0} file for more details.", Log.fullPath);
        }

        public static void writeToFile(string text) {
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

        public static bool fileMethod() {
            return File.Exists(fullPath) ? true : false;
        }

    }
}

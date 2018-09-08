using System;
using System.Configuration;
using System.IO;

namespace tieto_entry {

    class AppData {

        private string appDataPath = null;
        private string appName = null;

        public string path { get; private set; }

        public AppData() {
            path = null;
            appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            createDirectoryInAppData();
        }

        private void createDirectoryInAppData() {
            try {
                path = Path.Combine(appDataPath, appName);
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                    copyTestLoadData();
                }
            } catch (Exception e) {
                Console.WriteLine("Err: {0}", e.Message);
            }
        }

        private void copyTestLoadData() {
            string readFile = ConfigurationManager.AppSettings["readFile"];
            string sourcePath = AppDomain.CurrentDomain.BaseDirectory + readFile;
            string destinationPath = string.Format("{0}\\{1}", path, readFile);
            File.Copy(sourcePath, destinationPath, true);
        }

    }

}

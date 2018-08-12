using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    internal class Stream {
        // Filenames
        private string logFile = "log.txt"; // a log of what happens in the program
        private string statusFile = "status.txt"; // to remember status of pets and balls

        internal string StatusFile {
            get { return statusFile; }
        }

        internal void Log(string stringToLog) {
            WriteToFile(logFile, $"[{DateTime.Now}] {stringToLog}");
        }
        
        internal void SaveStatus(List<string> newData) {
            Log("<stream>Clears " + statusFile);
            File.Create(statusFile).Close(); // Clear file before updating data.
            foreach(string line in newData) {
                WriteToFile(statusFile, line);
            }
            Log("<stream>Adds the up to date data");
        }

        internal List<string> LoadStatus() {
            List<string> currentStatus = new List<string>();
            currentStatus.AddRange(ReadFromFile(statusFile));
            return currentStatus;
        }

        private List<string> ReadFromFile(string fileName) {
            List<string> lines = new List<string>();
            try {
                using(StreamReader streamReader = new StreamReader(fileName)) {
                    string line;
                    while((line = streamReader.ReadLine()) != null) {
                        lines.Add(line);
                    }
                }
            }
            catch(Exception e) {
                Console.WriteLine("The file could not be read: \n" + e.Message);
                Log("<stream> Error: " + e.Message);
                Console.ReadKey(true);
            }
            return lines;
        }

        private void WriteToFile(string fileName, string line) {
            try {
                using(StreamWriter streamWriter = new StreamWriter(fileName, true)) {
                    streamWriter.WriteLine(line);
                }
            }
            catch(Exception e) {
                Console.WriteLine("Unable to write to file: \n" + e.Message);
                Log("<stream> Error: " + e.Message);
                Console.ReadKey(true);
            }
        }
    }
}

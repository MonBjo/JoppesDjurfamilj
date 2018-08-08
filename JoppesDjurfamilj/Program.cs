using System;
using System.Collections.Generic;
using ConsoleTables;
using System.IO;

namespace JoppesDjurfamilj {
    class Program {
        static void Main(string[] args) {
            List<string> lines = ReadFromFile("status.txt");
            WriteToFile("log.txt", "Program started successfully");

            Petowner petowner = new Petowner();
            petowner.Menu();
            Console.WriteLine("The End");
            Console.ReadKey();
        }

        internal static void WriteToFile(string fileName, string text) {
            try {
                using(var streamWriter = new StreamWriter(fileName, true)) {
                    streamWriter.WriteLine($"[{DateTime.Now}]: {text}");
                    streamWriter.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        internal static List<string> ReadFromFile(string fileName) {
            List<string> lines = new List<string>();
            try {
                using(StreamReader streamReader = new StreamReader(fileName)) {
                    string line = streamReader.ReadLine();
                    while(line != null) {
                        lines.Add(line);
                        line = streamReader.ReadLine();
                    }
                    BadName(line);
                    streamReader.Close();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return lines;
        }

        private static void BadName(string line) {
            switch(line) {
                case "[pet]":
                break;
            }
        }

    }
}

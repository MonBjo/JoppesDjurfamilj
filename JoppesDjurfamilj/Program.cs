using System;
using System.Collections.Generic;
using ConsoleTables;
using System.IO;

namespace JoppesDjurfamilj {
    class Program {
        static void Main(string[] args) {
            List<string> lines = Stream.ReadFromFile("status.txt");
            Stream.WriteToFile("log.txt", "Program started successfully");

            Petowner petowner = new Petowner();
            petowner.Menu();
            Console.WriteLine("The End");
            Console.ReadKey();
        }
        
    }
}

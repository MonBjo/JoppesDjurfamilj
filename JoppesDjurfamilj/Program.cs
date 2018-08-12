using System;
using System.Collections.Generic;
using ConsoleTables;
using System.IO;

namespace JoppesDjurfamilj {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Loading, please wait...");
            Petowner petowner = new Petowner();
            petowner.Menu();
            Console.WriteLine("The End");
            Console.ReadKey();
        }
        
    }
}

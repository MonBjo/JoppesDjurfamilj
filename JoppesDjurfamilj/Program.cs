using System;

namespace JoppesDjurfamilj {
    class Program {
        static void Main(string[] args) {
            Petowner petowner = new Petowner();
            petowner.Menu();
            Console.WriteLine("The End");
            Console.ReadKey();
        }
    }
}

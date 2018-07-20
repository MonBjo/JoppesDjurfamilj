using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Petowner {
        // Defining data
        private int age = 0;
        private string name = "Joppe";
        private List<Animal> pets = new List<Animal>();
        private List<Ball> balls = new List<Ball>();
        private List<string> foods = new List<string>();



        public void Menu() {
            Console.WriteLine("=== Welcome to {0}'s Family of Pets ===", name);
            Console.WriteLine("[L] List animals\n" +
                              "[S] Storage\n" +
                              "[A] About this program\n" +
                              "[Q] Quit\n");
            ConsoleKeyInfo userInputMainMenu = Console.ReadKey(true);
            switch(userInputMainMenu.Key) {
                case ConsoleKey.L: {
                    // TODO: List animals, info, choose animal to interact with
                    break;
                }
                case ConsoleKey.S: {
                    // TODO: Undermenu to show availabe food and balls.
                    Console.WriteLine("=== The Storage ===\n *some info*");
                    Console.WriteLine("[F] Foods\n" +
                                      "[B] Balls\n" +
                                      "[R] Return\n");
                    ConsoleKeyInfo userInputSubMenuStorage = Console.ReadKey(true);
                    switch(userInputSubMenuStorage.Key) {
                        case ConsoleKey.F: {
                            // TODO: Show food
                            break;
                        }
                        case ConsoleKey.B: {
                            // TODO: Show balls
                            break;
                        }
                        case ConsoleKey.R: {
                            // TODO: Return
                            break;
                        }
                        default: {
                            // TODO: If the user don't make a menu choise...
                            break;
                        }
                    }
                    break;
                }
                case ConsoleKey.A: {
                    // TODO: About this program and how to use it.
                    break;
                }
                case ConsoleKey.Q: {
                    // TODO: Quit the program
                    break;
                }
                default: {
                    // TODO: If the user don't make a menu choise...
                    break;
                }
            }

        }
    }
}

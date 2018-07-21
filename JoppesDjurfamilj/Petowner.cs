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
            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to {0}'s Family of Pets ===", name);
                Console.WriteLine("[L] List pets\n" +
                                  "[S] Storage\n" +
                                  "[A] About this program\n" +
                                  "[Q] Quit\n");
                ConsoleKeyInfo userInputMainMenu = Console.ReadKey(true);
                switch(userInputMainMenu.Key) {
                    //  List animals
                    case ConsoleKey.L: {
                        // TODO: List animals, info, choose animal to interact with
                        Console.Clear();
                        Console.Write("Loads of pets\n" +
                                      "Type the ");
                        Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    //  Storage
                    case ConsoleKey.S: {
                        // TODO: Undermenu to show availabe food and balls.
                        while(true) {
                            Console.WriteLine("=== The Storage ===\n" +
                                             $"In {name}'s stoage you can find\n" +
                                              "anything the pets could ever need.\n" +
                                              "  [F] Foods\n" +
                                              "  [B] Balls\n" +
                                              "  [R] Return\n");
                            ConsoleKeyInfo userInputSubMenuStorage = Console.ReadKey(true);
                            switch(userInputSubMenuStorage.Key) {
                                case ConsoleKey.F: {
                                    // TODO: Show food
                                    Console.WriteLine("Food - amount - Pet/s who loves this");
                                    Console.WriteLine("============================\n" +
                                                      "Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                case ConsoleKey.B: {
                                    // TODO: Show balls
                                    Console.WriteLine("Ball size - Ball texture - amount");
                                    Console.WriteLine("============================\n" +
                                                      "Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                case ConsoleKey.R: {
                                    Console.WriteLine("  Returning... ");
                                    Console.ReadKey();
                                    continue;
                                }
                                default: {
                                    Console.WriteLine("  Ohps, please choose something in the menu");
                                    break;
                                }
                            }
                            break;
                        }
                        break;
                    }
                    //  About this program
                    case ConsoleKey.A: {
                        // TODO: About this program and how to use it.
                        Console.WriteLine("====================================\n" +
                                          "This is about Joppe and his family of pets\n" +
                                          "You can play with them, feed them.. \n" +
                                          "blablabla\n" +
                                          "*something about how to play*");
                        Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    case ConsoleKey.Q: {
                        Environment.Exit(0);
                        break;
                    }
                    default: {
                        // TODO: If the user don't make a menu choise...
                        Console.Clear();
                        Console.WriteLine("Ohps, please choose something in the menu");
                        break;
                    }
                }
            }

        }
    }
}

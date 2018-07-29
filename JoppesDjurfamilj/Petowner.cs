using System;
using System.Collections.Generic;
using ConsoleTables;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Petowner {
        // Defining data
        private int age = 0;
        private string name = "Joppe";
        private List<Ball> balls = new List<Ball>();
        private List<string> foods = new List<string>();
        private List<Animal> pets = new List<Animal> {
            new Dog(5, "Alfons", "Pork", "Andalusier"),
            new Puppy(8, "Bea", "Minced meat", "Terrier"),
            new HouseCat(7, "Charles", "Mice", "Norwegan Forestcat"),
            new Leopardus(3, "Diana", "Chiken", "Kodkod") // Yes thats legit
        };
        



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
                        ListAnimals();
                        while(true) { // TODO: Make the loop possible to break
                            Console.WriteLine($"Do you want {name} to interact with a pet (Y/N)?: ");
                            ConsoleKeyInfo userInputSubMenuPets = Console.ReadKey(true);
                            switch(userInputSubMenuPets.Key) {
                                case ConsoleKey.Y: {
                                    Console.Clear();
                                    ListAnimals();
                                    Console.WriteLine("Please choose a pet by writing its index: ");
                                    int petToInteractWith = Convert.ToInt32(Console.ReadLine());
                                    break;
                                }
                                case ConsoleKey.N: {
                                    Console.WriteLine("Then another time maybe");
                                    break;
                                }
                                default: {
                                    Console.WriteLine("Ohps, please choose Yes or No (Write Y or N)");
                                    break;
                                }
                            }
                        }
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
                                // Show foods
                                case ConsoleKey.F: {
                                    // TODO: Show food
                                    Console.WriteLine("Food - amount - Pet/s who loves this");
                                    Console.WriteLine("============================\n" +
                                                      "Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                // Show balls
                                case ConsoleKey.B: {
                                    // TODO: Show balls
                                    Console.WriteLine("Ball size - Ball texture - amount");
                                    Console.WriteLine("============================\n" +
                                                      "Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                // Return
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
                    // Quit
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

        public void ListAnimals() {
            int index = 0;
            ConsoleTable tablePets = new ConsoleTable("index", "Name", "Age", "Breed", "Favourite food");
            
            foreach(Animal pet in pets) {
                index++;
                tablePets.AddRow(index, pet.name, pet.age, pet.breed, pet.favFood);
            }
            tablePets.Write(Format.Alternative);
        }
    }
}

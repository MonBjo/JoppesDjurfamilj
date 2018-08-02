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
        private List<string> foods = new List<string>();
        private List<Animal> pets = new List<Animal> {
            new Dog(5, "Alfons", "Pork", "Andalusier"),
            new Puppy(8, "Bea", "Minced meat", "Terrier"),
            new HouseCat(7, "Charles", "Mice", "Norwegan Forestcat"),
            new Leopardus(3, "Diana", "Chiken", "Kodkod"), // Yes thats a legit breed
            new Dog(4, "Eevee", "Minced meat", "Corgie"),
            new Leopardus(9, "Frank", "Pork", "Kodkod"),
            new Puppy(1, "George", "Pork", "Poodle")
        };
        private List<Ball> balls = new List<Ball>(){
            new Ball("Red", "Smooth", 4, 30),
            new Ball("Blue", "Wavey", 6, 30),
            new Ball("Pink", "Super soft", 6, 30),
            new Ball("Green", "Grass like", 2, 30),
            new Ball("Yellow", "Knobby", 3, 30),
            new Ball("Green", "Hard", 5, 30)
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
                        Console.Clear();
                        ListAnimals();

                        bool continueLoop = true;
                        while(continueLoop) {
                            Console.Write($"Do you want {name} to interact with a pet (Y/N)?: ");
                            ConsoleKeyInfo userInputSubMenuPets = Console.ReadKey(true);

                            switch(userInputSubMenuPets.Key) {
                                // Yes, interact with a pet
                                case ConsoleKey.Y: {
                                    Console.Clear();
                                    int interactWithPet;
                                    ListAnimals();
                                    // Choose pet to interact with
                                    while(true) {
                                    Console.Write("Please choose a pet by writing its index: ");
                                        try {
                                            int userInputChoosePet = Convert.ToInt32(Console.ReadLine());

                                            if(userInputChoosePet < 0 || userInputChoosePet > pets.Count) {
                                                Console.WriteLine("Please write an integer between 1 and " + pets.Count);
                                            }
                                            else {
                                                interactWithPet = userInputChoosePet - 1; // The index of the actual list starts at 0. The displayed list starts at 1.
                                                Console.WriteLine("You choosed {0} to be interacted with!", pets[interactWithPet].name);
                                                break; //Sucessful input
                                            }
                                        }
                                        catch(FormatException) {
                                            Console.WriteLine("Please write only an integer");
                                        }
                                        catch(OverflowException) {
                                            Console.WriteLine("Please write an integer between 1 and " + pets.Count);
                                        }
                                    }
                                    
                                    Console.Clear();
                                    continueLoop = true;
                                    while(continueLoop) {
                                        Console.WriteLine($"What do you want {name} to do with {pets[interactWithPet].name}?\n" +
                                                           "[P] Play fetch\n" +
                                                           "[F] Feed\n" +
                                                           "[R] Return");
                                        ConsoleKeyInfo userInputSubMenuInteract = Console.ReadKey(true);
                                        switch(userInputSubMenuInteract.Key) {
                                            // Play fetch
                                            case ConsoleKey.P: {
                                                Console.Clear();
                                                Fetch(interactWithPet);
                                                Console.ReadKey(true);
                                                Console.WriteLine("============================\n" +
                                                                  "Press any key to continue...");
                                                break;
                                            }
                                            // Feed
                                            case ConsoleKey.F: {
                                                Console.Clear();
                                                Feed(interactWithPet);
                                                Console.ReadKey(true);
                                                Console.WriteLine("============================\n" +
                                                                  "Press any key to continue...");
                                                break;
                                            }
                                            // Return
                                            case ConsoleKey.R: {
                                                continueLoop = false;
                                                Console.WriteLine("============================\n" +
                                                                  "Press any key to continue...");
                                                break;
                                            }
                                            default: {
                                                Console.WriteLine("Please choose something in the menu");
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                                // No, don't interact with a pet
                                case ConsoleKey.N: {
                                    continueLoop = false;
                                    Console.WriteLine("\nThen another time maybe" +
                                                      "\n============================" +
                                                      "\nPress any key to continue...");
                                    Console.ReadKey(true);
                                    break;
                                }
                                default: {
                                    Console.WriteLine("\nOhps, please choose Yes or No (Write Y or N)");
                                    break;
                                }
                            }

                        }
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
                                    Console.Clear();
                                    ListFoods();
                                    Console.WriteLine("============================\n" +
                                                      "Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                // Show balls
                                case ConsoleKey.B: {
                                    Console.Clear();
                                    ListBalls();
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
            ConsoleTable table = new ConsoleTable("Index", "Name", "Age", "Breed", "Favourite food");
            int index = 0;

            foreach(Animal pet in pets) {
                index++;
                table.AddRow(index, pet.name, pet.age, pet.breed, pet.favFood);
            }
            table.Write(Format.Alternative);
        }

        public void ListFoods() {
            ConsoleTable table = new ConsoleTable("Index", "Food", "Pets who loves this");
            int index = 0;

            // Load foods-list
            foreach(Animal pet in pets) {
                bool isEqual = true;
                foreach(string food in foods) {
                    if(food == pet.favFood) {
                        isEqual = false;
                    }
                }
                if(isEqual) {
                    foods.Add(pet.FavFood);
                }
            }
            // Load table
            foreach(string food in foods) {
            StringBuilder petsFavFood = new StringBuilder();
                foreach(Animal pet in pets) {
                    if(food == pet.favFood) {
                        petsFavFood.Append(pet.name);
                        petsFavFood.Append(", ");
                    }
                }
                index++;
                petsFavFood.Remove(petsFavFood.Length - 2, 2);
                table.AddRow(index, food, petsFavFood);
            }
            table.Write(Format.Alternative);
        }

        public void ListBalls() {
            int index = 0;
            ConsoleTable table = new ConsoleTable("Index", "Color", "Size", "Texture", "Quality");
            foreach(Ball ball in balls) {
                index++;
                table.AddRow(index, ball.Color, ball.Size, ball.Texture, ball.Quality);
            }
            table.Write(Format.Alternative);
        }

        public void Fetch(int indexPet) {
            //TODO: Print something, call the Interact() method in the Animal class
        }

        public void Feed(int indexPet) {
            if(pets[indexPet].hungry) {
                Console.WriteLine("true - pet is hungry");
            }
            else {
                Console.WriteLine("false - pet is not hungry");
            }
            //TODO: Print something, list foods, ask what to give, call Eat() method in Animal class.
        }
    }
}

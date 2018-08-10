using System;
using System.Collections.Generic;
using ConsoleTables;
using System.Text;

namespace JoppesDjurfamilj {
    internal class Petowner {
        // Defining data
        private int age = 0;
        private string namePetowner = "Joppe";
        private List<string> foods = new List<string>();
        internal List<Animal> pets = new List<Animal> {
            new Dog(5, "Alfons", "Pork", "Andalusier"),
            new Puppy(8, "Bea", "Minced meat", "Terrier"),
            new HouseCat(7, "Charles", "Mice", "Norwegan Forestcat"),
            new Leopardus(3, "Diana", "Chiken", "Kodkod"), // Yes thats a legit breed
            new Dog(4, "Eevee", "Minced meat", "Corgie"),
            new Leopardus(9, "Frank", "Pork", "Kodkod"),
            new Puppy(1, "George", "Pork", "Poodle")
        };
        internal List<Ball> balls = new List<Ball>(){
            new Ball("Red", "Smooth", 4, 0),
            new Ball("Blue", "Wavey", 6, 10),
            new Ball("Pink", "Super soft", 6, 16),
            new Ball("Green", "Grass like", 2, 22),
            new Ball("Yellow", "Knobby", 3, 27),
            new Ball("Green", "Hard", 5, 29),
            new Ball("Blue", "Smooth", 3, 30)
        };

        internal List<Animal> GetPets {
            get { return pets; }
            set { pets = value; }
        }

        public Petowner() {
            int index = 0;
             foreach(Animal pet in pets) {
                Stream.WriteToFile(Stream.statusFile, $"[Pet][{index}] {pet.Name},{pet.Age},{pet.Breed},{pet.Hungry},{pet.favFood}");
                index++;
            }

            index = 0;
            foreach(Ball ball in balls) {
                Stream.WriteToFile(Stream.statusFile, $"[Ball][{index}] {ball.Color},{ball.Size},{ball.Texture},{ball.Quality}");
                index++;
            }
        }

        public void Menu() {
            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to {0}'s Family of Pets ===", namePetowner);
                Console.WriteLine("[L] List pets\n" +
                                  "[P] Play fetch\n" +
                                  "[F] Feed a pet\n" +
                                  "[S] Storage\n" +
                                  "[A] About this program\n" +
                                  "[Q] Quit\n");
                ConsoleKeyInfo userInputMainMenu = Console.ReadKey(true);
                switch(userInputMainMenu.Key) {
                    //  List animals
                    case ConsoleKey.L: {
                        Console.Clear();
                        ListAnimals();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    }
                    // Play fetch
                    case ConsoleKey.P: {
                        Console.Clear();
                        Fetch();
                        Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    }
                    // Feed a pet
                    case ConsoleKey.F: {
                        Console.Clear();
                        Feed();
                        Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    }
                    //  Storage
                    case ConsoleKey.S: {
                        while(true) {
                            Console.WriteLine("=== The Storage ===\n" +
                                             $"In {namePetowner}'s stoage you can find\n" +
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
                                    int indexBall = 4;

                                    ListBalls(true);
                                    while(true) {
                                        try {
                                            Console.WriteLine($"If you want {namePetowner} to check on a ball, write its index.\n" +
                                                               "If not, leave it blank and press enter.");
                                            //int userInputSubMenuBall = Convert.ToInt32(Console.ReadLine());
                                            string userInputSubMenuBall = Console.ReadLine();
                                            if(userInputSubMenuBall == "") {
                                                break;
                                            }
                                            else {
                                                indexBall = Convert.ToInt32(userInputSubMenuBall);
                                                indexBall--; // The list of balls begins at 0, not 1
                                                CheckBall(indexBall);
                                                break;
                                            }
                                        }
                                        catch(FormatException) {
                                            Console.WriteLine("Please write an integer between 1 and {0} or leave it blank, then press enter.", balls.Count);
                                        }
                                        catch(Exception e) {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
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
                        Console.WriteLine("====================================\n" +
                                          "This is about Joppe and his family of pets.\n" +
                                          " To interact with the pets Joppe can" +
                                          " play with them or feed them.There are several" +
                                          " dishes to choose from and also several different" +
                                          " kinds of balls. \n Of course, the animals will react" +
                                          " different depending on what is offered. ");
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
                        Console.Clear();
                        Console.WriteLine("Ohps, please choose something in the menu");
                        break;
                    }
                }
            }
        }

        public void ListAnimals() {
            ConsoleTable table = new ConsoleTable("Index", "Name", "Age", "Breed");
            int index = 0;

            foreach(Animal pet in pets) {
                index++;
                table.AddRow(index, pet.Name, pet.AgeString(), pet.Breed);
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
                        petsFavFood.Append(pet.Name);
                        petsFavFood.Append(", ");
                    }
                }
                index++;
                petsFavFood.Remove(petsFavFood.Length - 2, 2);
                table.AddRow(index, food, petsFavFood);
            }
            table.Write(Format.Alternative);
        }
        
        public void ListBalls(bool showBroken) {
            int index = 0;
            ConsoleTable table = new ConsoleTable("Index", "Color", "Size", "Texture", "Quality");
            foreach(Ball ball in balls) {
                index++;
                if(showBroken) {
                    table.AddRow(index, ball.Color, ball.Size, ball.Texture, ball.QualityString());
                }
                else{
                    if(ball.Quality == 0) {
                        continue;
                    }
                    else {
                        table.AddRow(index, ball.Color, ball.Size, ball.Texture, ball.QualityString());
                    }
                }
            }
            table.Write(Format.Alternative);
        }

        public void Fetch() {
            Console.Clear();
            ListAnimals();
            int interactWithPet;
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
                        Console.WriteLine("You choose to play with {0}!", pets[interactWithPet].name);
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
            ListBalls(false); // Do not show broken balls
            int indexBall;
            // Choose ball to use
            while(true) {
                Console.Write("Please choose a ball by writing its index: ");
                try {
                    int userInputChooseBall = Convert.ToInt32(Console.ReadLine());

                    if(userInputChooseBall < 0 || userInputChooseBall > pets.Count) {
                        Console.WriteLine("Please write an integer between 1 and " + balls.Count);
                    }
                    else {
                        indexBall = userInputChooseBall - 1; // The index of the actual list starts at 0. The displayed list starts at 1.
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
            pets[interactWithPet].Interact(balls[indexBall]);
        }

        public void CheckBall(int indexBall) {
            Random random = new Random();
            switch(balls[indexBall].Quality) {
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.Write("\"Half of the ball is missing. Should I buy a new one?\" (Y/N) ");
                    FixBall();
                    break;

                case 5:
                case 6:
                case 8:
                case 9:
                case 10:
                    Console.Write("\"The ball fell into pieces in my hand.. I could try and tape it together again.\" (Y/N) ");
                    FixBall();
                    break;

                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    Console.Write("\"Oh my, it has lost a big chunk, some glue might do. \" (Y/N) ");
                    FixBall();
                    break;

                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    Console.Write("\"It has this big hole, I could sew it.\" (Y/N) ");
                    FixBall();
                    break;

                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                    Console.Write("\"It has some scratches and a few holes. Should I fill them with something?\" (Y/N) ");
                    FixBall();
                    break;

                case 28:
                case 29:
                    Console.Write("\"It's like new, only a few scratches. I could polish it maybe?\" (Y/N) ");
                    FixBall();
                    break;

                case 30:
                    Console.WriteLine("\"This is brand new!\"");
                    break;
            }

            void FixBall() {
                bool continueLoop = true;
                while(continueLoop) {
                    ConsoleKeyInfo userInput = Console.ReadKey(true);
                    switch(userInput.Key) {
                        // Yes, fix the ball
                        case ConsoleKey.Y: {
                            if(balls[indexBall].Quality < 4) {
                                balls[indexBall].Quality = Ball.maxQuality;
                            }
                            else {
                                int qualityUp = random.Next(5);
                                balls[indexBall].Quality += qualityUp;

                                if(balls[indexBall].Quality > Ball.maxQuality) {
                                    balls[indexBall].Quality = Ball.maxQuality;
                                }
                            }

                            continueLoop = false;
                            break;
                        }
                        // No, don't fix the ball
                        case ConsoleKey.N: {
                            continueLoop = false;
                            break;
                        }
                        default: {
                            Console.Write("\nPlease write [Y] yes or [N] no: ");
                            break;
                        }
                    }

                }
            }

        }

        public void Feed() {
            Console.Clear();
            int petIndex;
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
                        petIndex = userInputChoosePet - 1; // The index of the actual list starts at 0. The displayed list starts at 1.
                        Console.WriteLine("You choose to feed {0}!", pets[petIndex].name);
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
            ListFoods();
            int foodIndex;
            while(true) {
                Console.Write("Please choose a food by typing it's index: ");

                try {
                    int userInputChooseFood = Convert.ToInt32(Console.ReadLine());

                    if(userInputChooseFood < 0 || userInputChooseFood > foods.Count) {
                        Console.WriteLine("Please write an integer between 1 and " + foods.Count);
                    }
                    else {
                        foodIndex = userInputChooseFood - 1;
                        Console.WriteLine("{0} tries to feed {1} with {2}", namePetowner, pets[petIndex].Name, foods[foodIndex]);
                        pets[petIndex].Eat(foods[foodIndex]);
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

        }
    }
}

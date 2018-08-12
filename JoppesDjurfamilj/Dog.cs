using System;

namespace JoppesDjurfamilj {
    class Dog : Animal{
        public Dog(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed; 
        }

        public override void Interact(Ball ball) {
            if(Hungry) {
                Console.WriteLine("{0} nudges the ball and sits down", Name);
                stream.Log($"<{baseClassName}> Too hungry to play");
            }
            else {
                Console.WriteLine("{0} runs after it furiosly and quickly runs back, all while barking", Name);

                int lowerQuality = random.Next(7);
                ball.Quality -= lowerQuality;
                if(ball.Quality < 0) {
                    ball.Quality = 0;
                    Console.WriteLine(ball + " is now broken");
                }
                stream.Log($"<{baseClassName}> Quality went down to " + ball.Quality);
                stream.Log($"<{baseClassName}> Successfully played with pet");
            }
        }

        public override void HungryAnimal() {
            Console.WriteLine("{0} takes a nibble of the food and whimpers. Refusing to eat more.", Name);
        }

        public override string ToString() {
            return $"{Name}, Dog";
        }

    }
}

using System;

namespace JoppesDjurfamilj {
    class HouseCat : Cat {
        public HouseCat(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed;
        }

        public override void Interact(Ball ball) {
            if(Hungry) {
                Console.WriteLine("{0} ignores the ball", Name);
                stream.Log("Too hungry to play");
            }
            else {
                Console.WriteLine("{0} hides and gets ready to hunt the {1} with a big jump.", Name, ball);

                int lowerQuality = random.Next(4);
                ball.Quality -= lowerQuality;
                if(ball.Quality < 0) {
                    ball.Quality = 0;
                    Console.WriteLine(ball + " is now broken");
                }
                stream.Log("Quality went down to " + ball.Quality);
            }
        }

        public override void HungryAnimal() {
            Console.WriteLine("{0} whines a bit before walking away", Name);
        }

        public override string ToString() {
            return $"{Name}, House cat";
        }

    }
}

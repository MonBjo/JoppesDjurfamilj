using System;

namespace JoppesDjurfamilj {
    class Leopardus : Cat {
        public Leopardus(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed;
        }

        public override void Interact(Ball ball) {
            if(Hungry) {
                Console.WriteLine("{0} hisses slightly.", Name);
            }
            else {
                Console.WriteLine("{0} ignores the ball and climbes the cat-tree instead.", Name);
            }
                stream.Log($"<{baseClassName}> Not intersted in playing");
        }

        public override string ToString() {
            return $"{Name}, Leopardus";
        }

    }
}

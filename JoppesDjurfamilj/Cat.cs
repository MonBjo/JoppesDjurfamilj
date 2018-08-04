using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Cat : Animal {
        public Cat(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed;
        }

        public override void Interact(Ball ball) {
            throw new NotImplementedException();
            //TODO: if hungry -> doesn't want to play
            //TODO: if not hungry -> Want to play -> good ball -> plays -> becomes hungry
            //TODO: if not hungry -> Want to play -> bad ball -> doesn't play
        }

        public override void HungryAnimal() {
            Console.WriteLine("{0} whines a bit before walking away", Name);
            int catchMice = random.Next(3);
            if(catchMice == 0) {
                Hungry = true;
            }
            else {
                Console.WriteLine("... after a few minutes {0} is back with a mice", Name);
                Hungry = false;
            }
        }

        public override string ToString() {
            return $"{Name}, Cat";
        }
    }
}

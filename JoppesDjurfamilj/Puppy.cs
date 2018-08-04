using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Puppy : Dog {
        public Puppy(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed; 
        }
        // TODO: Puppy age is in month and not years!

        public override void Interact(Ball ball) {
            throw new NotImplementedException();
            //TODO: if hungry -> doesn't want to play
            //TODO: if not hungry -> Want to play -> good ball -> plays -> becomes hungry
            //TODO: if not hungry -> Want to play -> bad ball -> doesn't play
        }

        public override void HungryAnimal() {
            throw new NotImplementedException();
            //TODO: reacts on food it dislikes
        }

        public override string AgeString() {
            return $"{Age} months";
        }

        public override string ToString() {
            return $"{Name}, Puppy";
        }
    }
}

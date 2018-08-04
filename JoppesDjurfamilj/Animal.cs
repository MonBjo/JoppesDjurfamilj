using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    abstract class Animal {
        internal int age = 0;
        internal string name = "";
        internal string favFood = "";
        internal int favBall = "";
        internal string breed = "";
        internal bool hungry = true;

        public int Age {
            get { return age; }
            set { age = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string FavFood {
            get { return favFood; }
            set { favFood = value; }
        }

        public int FavBall {
            get { return favBall; }
            set { favBall = value; }
        }

        public string Breed {
            get { return breed; }
            set { breed = value; }
        }

        public bool Hungry {
            get { return hungry; }
            set { hungry = value; }
        }

        public Animal(int _age, string _name, string _favFood, string _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed;
        }

        public abstract void Interact(Ball ball);

        public abstract void HungryAnimal();

        public void Eat(string food) {
            if(!Hungry) {
                Console.WriteLine(Name + " is not hungry");
            }
            else {

                if(food == FavFood) {
                    Console.WriteLine("Accepts food"); //TODO: Write something better
                    Hungry = false;
                }
                else {
                    HungryAnimal();
                }

            }
        }

        public virtual string AgeString() {
            return $"{Age} years";
        }

        public override string ToString() {
            return Name;
        }

    }
}

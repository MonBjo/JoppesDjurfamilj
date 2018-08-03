using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    abstract class Animal {
        Random random = new Random();
        internal int age = 0;
        internal string name = "";
        internal string favFood = "";
        internal string breed = "";
        internal bool hungry = false;

        public int Age {
            get { return age; }
            set { value = age; }
        }

        public string Name {
            get { return name; }
            set { value = name; }
        }

        public string FavFood {
            get { return favFood; }
            set { value = favFood; }
        }

        public string Breed {
            get { return breed; }
            set { value = breed; }
        }

        public bool Hungry {
            get { return hungry; }
            set { hungry = value; }
        }

       public void TestHunger() {
            int boolean = random.Next(2);
            if(boolean == 0) {
                Hungry = false;
            }
            else {
                Hungry = true;
            }
        }

        public Animal(int _age, string _name, string _favFood, string _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed;
        }

        public abstract void Interact(Ball ball);

        public abstract void HungryAnimal();

        public void Eat() {
            //if(foods[foodIndex] == pets[petIndex].FavFood) {
            //    pets[petIndex].Eat();
            //}
            //else {
            //    pets[petIndex].HungryAnimal();
            //}
        }
    }
}

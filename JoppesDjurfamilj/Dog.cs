using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Dog : Animal{
        public Dog(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            //*
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed; //*/
        }
    }
}

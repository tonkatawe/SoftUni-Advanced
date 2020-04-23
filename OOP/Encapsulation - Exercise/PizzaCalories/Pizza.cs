using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toppings;
        private string name;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public int toppingsCount => this.toppings.Count;
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppingsCount > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);

        }

        public double GetCalories()
        {
            var result = this.dough.GetCalories() + this.toppings.Sum(x => x.GetCalories());
            return result;
        }
    }
}

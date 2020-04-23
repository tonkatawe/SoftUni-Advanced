using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppings;
        private double weight;

        public Topping(string topping, double weight)
        {
            this.Toppings = topping;
            this.Weight = weight;
        }

        public string Toppings
        {
            get => this.toppings;
            set
            {
                if (!ToppingValidator.IsValidTopping(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");

                }
                this.toppings = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.toppings} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var result = 2 * this.Weight * ToppingValidator.GetModifier(this.toppings);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string typeFlour;
        private string bakingTech;
        private double weight;

        public Dough(string typeFlour, string bakingTech, double weight)
        {
            this.TypeFlour = typeFlour;
            this.BakingTech = bakingTech;
            this.Weight = weight;
        }
        //I`m not sure but might be must to implimate the exception in setters
        public string TypeFlour
        {
            get => this.typeFlour;
            private set
            {
                if (!DoughValidator.IsValidFlourType(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.typeFlour = value;
            }
        }
        public string BakingTech
        {
            get => this.bakingTech;
            private set
            {
                if (!DoughValidator.IsValidBakingTech(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.bakingTech = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var result = 2 * this.Weight
                     * DoughValidator.GetFlourModifier(this.typeFlour)
                     * DoughValidator.GetTechModifier(this.bakingTech);
            return result;
        }
    }
}

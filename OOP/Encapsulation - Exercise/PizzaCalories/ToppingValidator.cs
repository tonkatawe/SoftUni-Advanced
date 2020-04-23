using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PizzaCalories
{
    public static class ToppingValidator
    {
        private static Dictionary<string, double> toppings = new Dictionary<string, double>();

        public static bool IsValidTopping(string topping)
        {
            Initialize();
            if (!toppings.ContainsKey(topping.ToLower()))
            {
                return false;
            }

            return true;
        }
        private static void Initialize()
        {
            if (toppings.Count != 0)
            {
                return;
            }
            toppings.Add("meat", 1.2);
            toppings.Add("veggies", 0.8);
            toppings.Add("cheese", 1.1);
            toppings.Add("sauce", 0.9);
        }

        public static double GetModifier(string topping) => toppings[topping.ToLower()];
    }
}

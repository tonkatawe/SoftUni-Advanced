using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public static class DoughValidator
    {
        
        private static Dictionary<string, double> flourType = new Dictionary<string, double>();
        private static Dictionary<string, double> bakingTech = new Dictionary<string, double>();

        public static bool IsValidFlourType(string type)
        {
            Initialize();
            if (!flourType.ContainsKey(type.ToLower()))
            {
                return false;
            }
            return true;
        }
        public static bool IsValidBakingTech(string type)
        {
            Initialize();
            if (!bakingTech.ContainsKey(type.ToLower()))
            {
                return false;
            }
            return true;
        }
        private static void Initialize()
        {
            if (flourType.Count != 0 && bakingTech.Count != 0)
            {
                return;
            }
            //Initialize requirements about flour`s type.Where (d => double.Calories)
            flourType.Add("white", 1.5);
            flourType.Add("wholegrain", 1.0);
            //Initialize requirements about baking techniques.Where (the same above )
            bakingTech.Add("crispy", 0.9);
            bakingTech.Add("chewy", 1.1);
            bakingTech.Add("homemade", 1);


        }

        public static double GetFlourModifier(string type) => flourType[type.ToLower()];

        public static double GetTechModifier(string type) => bakingTech[type.ToLower()];
    }
}

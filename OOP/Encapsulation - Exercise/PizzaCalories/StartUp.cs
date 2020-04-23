using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)

        {
            try
            {



                //read pizza
                var pizzaInput = ParseArrFromConsole();
                var name = pizzaInput[1];
                //read Dough
                var doughInput = ParseArrFromConsole();
                var flourType = doughInput[1];
                var bakeTech = doughInput[2];
                var weight = double.Parse(doughInput[3]);
                var dough = new Dough(flourType, bakeTech, weight);
                //make a pizzza
                var pizza = new Pizza(name, dough);
                //read toppings
                while (true)
                {
                    var command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    var toppingInput = command.Split().ToArray();
                    var type = toppingInput[1];
                    var weightTopping = double.Parse(toppingInput[2]);
                    var topping = new Topping(type, weightTopping);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }

        }

        public static string[] ParseArrFromConsole()
        {
            return Console.ReadLine()
                  .Split()
                  .ToArray();
        }
    }
}

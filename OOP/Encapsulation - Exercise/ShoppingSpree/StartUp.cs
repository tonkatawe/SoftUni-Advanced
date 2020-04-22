namespace ShoppingSpree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        //60/100 by judge :)
        public static void Main(string[] args)
        {
            var peopleAndMoney = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productAndPrice = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            try
            {
                foreach (var person in peopleAndMoney)
                {
                    var nameAndMoney = person.Split('=');
                    var name = nameAndMoney[0];
                    var money = decimal.Parse(nameAndMoney[1]);
                    var currentPerson = new Person(name, money);
                    people.Add(currentPerson);
                }

                foreach (var product in productAndPrice)
                {
                    var typeAndPrice = product.Split('=');
                    var type = typeAndPrice[0];
                    var price = decimal.Parse(typeAndPrice[1]);
                    var currentProduct = new Product(type, price);
                    products.Add(currentProduct);
                }

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    var tokens = input.Split();
                    var name = tokens[0];
                    var productType = tokens[1];
                    var person = people.FirstOrDefault(x => x.Name == name);
                    var product = products.FirstOrDefault(x => x.Name == productType);
                    person.BuyProduct(product);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




            //   var money = decimal.Parse(firstLine[1]);
        }
    }
}

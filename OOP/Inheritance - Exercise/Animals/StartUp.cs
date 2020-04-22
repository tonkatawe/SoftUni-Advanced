using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();
            while (true)
            {
                string animalType;
                var command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }
                else
                {
                    animalType = command;
                    var data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var name = data[0];
                    var age = int.Parse(data[1]);
                    string gender = string.Empty;
                    if (data.Length == 3)
                    {
                        gender = data[2];
                    }

                    try
                    {

                        if (animalType == "Dog")
                        {
                            animals.Add(new Dog(name, age, gender));
                        }
                        else if (animalType == "Cat")
                        {
                            animals.Add(new Cat(name, age, gender));
                        }
                        else if (animalType == "Frog")
                        {
                            animals.Add(new Frog(name, age, gender));
                        }
                        else if (animalType == "Kitten")
                        {
                            animals.Add(new Kitten(name, age));
                        }
                        else if (animalType == "Tomcat")
                        {
                            animals.Add(new Tomcat(name, age));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }



            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);

            }
        }
    }
}

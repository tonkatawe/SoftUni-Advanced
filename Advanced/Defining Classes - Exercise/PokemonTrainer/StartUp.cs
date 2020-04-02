using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Tournament")
                {
                    break;
                }

                var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var health = int.Parse(tokens[3]);
                var trainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                if (trainer != null)
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, health));
                }
                else
                {
                    var newTrainer = new Trainer(trainerName);
                    newTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, health));
                    trainers.Add(newTrainer);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].Pokemons.Any(x => x.Element == input))
                    {
                        foreach (var item in trainers[i].Pokemons)
                        {
                            item.ReduceHealth();

                        }
                        trainers[i].IncreaseBadges();
                    }
                }
            }
            trainers.OrderByDescending(x => x.Bages)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Bages} {x.Pokemons.Count}"));
        }
    }
}

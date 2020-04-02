using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int bages;
        private HashSet<Pokemon> pokemons;

        public Trainer()
        {
            this.Bages = 0;
            this.Pokemons = new HashSet<Pokemon>();
        }

        public Trainer(string name)
        : this()
        {
            this.Name = name;
        }
        public Trainer(string name, HashSet<Pokemon> pokemons)
        : this(name)
        {
            this.Pokemons = pokemons;
        }

        public Trainer(string name, int bages, HashSet<Pokemon> pokemons)
        : this()
        {
            this.Name = name;
            this.Bages = bages;
            this.Pokemons = pokemons;
        }
        public string Name
        {
            get
            {
                return this.name;

            }
            set
            {
                this.name = value;
            }
        }

        public int Bages
        {
            get
            {
                return this.bages;
            }
            set
            {
                this.bages = value;

            }
        }

        public HashSet<Pokemon> Pokemons
        {
            get
            {
                return this.pokemons;
            }
            set
            {
                this.pokemons = value;
            }
        }

        public void IncreaseBadges()
        {
            this.Bages++;
        }
       
    }
}

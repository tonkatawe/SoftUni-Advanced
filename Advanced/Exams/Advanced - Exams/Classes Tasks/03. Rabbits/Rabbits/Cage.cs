using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        private Cage()
        {
            this.data = new List<Rabbit>();
        }

        public Cage(string name, int capacity)
        : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count + 1 <= Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name);
            if (rabbit != null)
            {
                this.data.Remove(rabbit);
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {

            this.data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name && r.Available == true);
            if (rabbit != null)
            {
                rabbit.Available = false;
            }

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var result = this.data
                .Where(x => x.Species == species && x.Available == true).ToArray();
            foreach (var rabit in result)
            {
                rabit.Available = false;
            }

            return result;
        }

        public string Report()
        {
            var result = new StringBuilder();
            result.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data.Where(x => x.Available == true))
            {
                result.AppendLine(rabbit.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }

}

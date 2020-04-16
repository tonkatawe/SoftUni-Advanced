using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Christmas
{
    public class Bag
    {
        private HashSet<Present> data;

        private Bag()
        {
            this.data = new HashSet<Present>();
        }
        public Bag(string color, int capacity)
        : this()
        {
            this.Color = color;
            this.Capacity = capacity;
        }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;


        public void Add(Present present)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(present);
            }
        }


        public bool Remove(string name)
        {

            var present = this.data.FirstOrDefault(p => p.Name == name);
            if (present.Name != null)
            {
                this.data.Remove(present);
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            return this.data.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            var present = this.data.FirstOrDefault(p => p.Name == name);
            if (present != null)
            {
                return present;
            }
            return present;
        }
        public string Report()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.Color} bag contains:");
            foreach (var present in this.data)
            {
                result.AppendLine(present.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}

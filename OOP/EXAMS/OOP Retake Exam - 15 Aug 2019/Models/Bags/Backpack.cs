
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
       
        public Backpack()
        {
            this.Items = new List<string>();
        }
        public ICollection<string> Items { get; private set; }
    }
}

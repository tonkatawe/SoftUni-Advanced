using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }
        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"  * Strength: {this.Strength}");
            result.AppendLine($"  * Ability: {this.Ability}");
            result.AppendLine($"  * Intelligence: {this.Intelligence}");
            return result.ToString().TrimEnd();
        }
    }
}

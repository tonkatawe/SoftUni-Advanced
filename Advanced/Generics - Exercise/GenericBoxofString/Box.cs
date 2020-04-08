using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }

        public List<T> Values
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> values, int firstIndex, int secondIndex)
        {
            if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < values.Count && secondIndex < values.Count)
            {
                var currentIndex = values[firstIndex];
                values[firstIndex] = values[secondIndex];
                values[secondIndex] = currentIndex;
            }
        }

        public int Counter(List<T> values, T element)
        {
            var counter = 0;
            foreach (var value in values)
            {
                if (value.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}

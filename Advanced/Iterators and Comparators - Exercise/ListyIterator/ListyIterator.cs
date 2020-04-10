using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> items)
        {
            this.items = items;
            this.index = 0;
        }

        public void Print()
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Invalid operation!");
            }

            Console.WriteLine(items[this.index]);
        }
        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.index < this.items.Count -1)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Data_Structures
{
    public class MyLIst
    {
        private const int initialCapacity = 2;
        private int[] items;

        public MyLIst()
        {
            this.items = new int[initialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        private void ShifToRight(int index)
        {
            for (int i = Count; i < index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.items.Length == this.Count)
            {
                this.Resize();
            }

            this.ShifToRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex > this.Count - 1 || secondIndex > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            else
            {
                var current = items[firstIndex];
                this.items[firstIndex] = items[secondIndex];
                this.items[secondIndex] = current;
            }
        }
    }

}



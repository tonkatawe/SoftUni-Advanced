using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Data_Structures
{
    public class MyStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public MyStack()
        {
            this.count = 0;
            this.items = new int[initialCapacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push(int element)
        {
            if (this.items.Length == this.count)
            {
                var nextItems = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    nextItems[i] = this.items[i];
                }

                this.items = nextItems;
            }

            this.items[this.count] = element;
                this.count++;
        }

        public int Pop()
        {
            if (this.items.Length ==0)
            {
                throw new InvalidOperationException("This stack is empty");
            }

            var lastIndex = this.count - 1;
            int last = this.items[lastIndex];
            this.count--;
            return last;
        }

        public int Peek()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("This stack is empty");
            }

            return this.count - 1;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}

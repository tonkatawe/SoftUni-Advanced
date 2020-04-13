using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index = -1;

        public MyStack()
        {
            this.items = new List<T>();

        }

        public void Push(params T[] elements)
        {
            foreach (var item in elements)
            {
                this.items.Add(item);
            }
        }

        public void Pop()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            this.items.RemoveAt(this.items.Count -1);
        }




        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

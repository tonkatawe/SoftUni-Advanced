using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T Left { get; }
        public T Right { get; }
        public bool AreEqual()
        {
            return this.Left.Equals(this.Right);
        }
    }
}

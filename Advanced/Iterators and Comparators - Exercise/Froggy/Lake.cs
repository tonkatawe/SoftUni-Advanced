using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] numbers;

        public Lake(params int[] stones)
        {
            this.numbers = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.numbers.Length; i += 2)
            {
                yield return this.numbers[i];
            }

            for (int i = this.numbers.Length - 1; i >= 0; i--)
            {
                if (i %2 !=0)
                {
                    yield return this.numbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

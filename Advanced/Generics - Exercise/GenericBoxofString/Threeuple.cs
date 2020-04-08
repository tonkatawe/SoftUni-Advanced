using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofString
{
    public class Threeuple<Tfirst, TSecond, TThird>
    {
        public Threeuple(Tfirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            this.First = firstItem;
            this.Second = secondItem;
            this.Third = thirdItem;
        }
        public Tfirst First { get; set; }
        public TSecond Second { get; set; }
        public TThird Third { get; set; }
        public override string ToString()
        {
            return $"{this.First} -> {this.Second} -> {this.Third}";
        }
    }
}

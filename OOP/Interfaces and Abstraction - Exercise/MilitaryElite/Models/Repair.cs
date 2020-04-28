using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class Repair : IRepair
    {
        private string part;
        private int hours;

        public Repair(string part, int hours)
        {
            this.Part = part;
            this.Hours = hours;
        }
        public string Part
        {
            get => this.part;
            private set
            {
                this.part = value;
            }
        }
        public int Hours
        {
            get => this.hours;
            private set { this.hours = value; }
        }

        public override string ToString()
        {
            return $"Part Name: {this.Part} Hours Worked: {this.Hours}";
        }
    }
}

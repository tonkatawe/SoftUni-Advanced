using System;
using System.Collections.Generic;
using System.Text;

namespace Special_Cars
{
   public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.pressure = pressure;
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.pressure = value;
            }
        }
    }
}

namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private double cubicCentimeters;
        private int horsePower;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 4)
                {
                    var exMsg = String.Format(ExceptionMessages.InvalidModel, value,4);
                    throw new ArgumentException(exMsg);
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set => this.horsePower = value;
        }
        public double CubicCentimeters
        {
            get => this.CubicCentimeters;
            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            var result = (this.CubicCentimeters / this.HorsePower) * laps;
            return result;
        }
    }
}
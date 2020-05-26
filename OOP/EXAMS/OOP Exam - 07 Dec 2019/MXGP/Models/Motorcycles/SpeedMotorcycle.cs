namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MinimumHorsePower = 50;
        private const int MaximumHorsePower = 69;
        private const int InitialCubicCentimeters = 125;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters)
        {
            if (horsePower < MinimumHorsePower || horsePower > MaximumHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }

    }
}

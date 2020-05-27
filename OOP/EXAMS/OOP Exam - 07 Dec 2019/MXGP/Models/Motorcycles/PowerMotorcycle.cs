namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;
    public class PowerMotorcycle : Motorcycle
    {
        private const int MinimumHorsePower = 70;
        private const int MaximumHorsePower = 100;
        private const int InitialCubicCentimeters = 450;
        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters)
        {
            if (horsePower < MinimumHorsePower || horsePower > MaximumHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }

        }


    }
}

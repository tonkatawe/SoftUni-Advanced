using System;

namespace _4._Hotel_Reservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            var input = Console.ReadLine()
                .Split();
            var pricePerDay = decimal.Parse(input[0]);
            var numberOfDays = int.Parse(input[1]);
            var season = Enum.Parse<Season>(input[2]);
            var discountType = Enum.Parse<Discount>(input[3]);
            Console.WriteLine($"{PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discountType):F2}");

        }
    }
}

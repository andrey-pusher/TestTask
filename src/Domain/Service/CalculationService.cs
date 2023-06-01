using Domain.Enumerations;

namespace Domain.Service
{
    public class CalculationService
    {
        public const int MINIMAL_VALUE = 0;
        public const int FIRST_BANK_MULTIPLIER = 3;
        public const int THIRD_BANK_SUBTRACTOR = 100;
        public const int HALF_SHARE = 50;
        public const int FULL_SHARE = 100;

        public decimal GetValue(Bank bank, decimal existed, decimal offset)
        {
            var result = bank switch
            {
                (Bank)0 => existed + (offset * FIRST_BANK_MULTIPLIER),
                (Bank)1 => existed - GetPercent(offset, HALF_SHARE),
                (Bank)2 => existed + GetPercent(offset, HALF_SHARE) - THIRD_BANK_SUBTRACTOR,
                _ => existed + offset
            };

            return result >= MINIMAL_VALUE ? result : MINIMAL_VALUE;
        }

        public decimal GetPercent(decimal value, decimal percent) =>
            Math.Round(value / FULL_SHARE * percent);
    }
}

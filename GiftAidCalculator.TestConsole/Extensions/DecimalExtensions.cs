namespace GiftAidCalculator.TestConsole.Extensions
{
    public static class DecimalExtensions
    {
        private const int _decimalPoints = 2;
        public static decimal RoundDecimal(this decimal value)
        {
            return decimal.Round(value, _decimalPoints);
        }
    }
}

namespace GiftAidCalculator.TestConsole.Models
{
    public class Event
    {
        public virtual decimal Supplement { get { return 0; } }
        public decimal GetSupplement()
        {

            return 1 + Supplement / 100;
        }
    }
}

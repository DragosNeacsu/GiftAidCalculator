namespace GiftAidCalculator.TestConsole.Models
{
    public class Admin : User
    {
        public override bool isAdmin { get { return true; } }
    }
}

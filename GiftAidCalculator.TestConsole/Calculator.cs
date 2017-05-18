using GiftAidCalculator.TestConsole.Extensions;
using GiftAidCalculator.TestConsole.Models;
using System;

namespace GiftAidCalculator.TestConsole
{
    public class Calculator
    {
        private decimal _taxRate = 20;
        private Event _event;
        private User _user;
        public Calculator(User user)
        {
            _user = new User();
            _event = new Event();
        }

        public void ChangeTaxRate(decimal newTaxRate)
        {
            if (_user.isAdmin)
            {
                _taxRate = newTaxRate;
            }
        }

        public decimal Calculate(decimal donationAmount)
        {
            if (donationAmount <= 0)
            {
                throw new ArgumentException("amount should be grater than 0");
            }

            var result = donationAmount * (_taxRate / (100 - _taxRate));
            return result.RoundDecimal() * _event.GetSupplement();
        }

        public void AddEvent(Event theEvent)
        {
            _event = theEvent;
        }

        public void Login(User user)
        {
            _user = user;
        }
    }
}

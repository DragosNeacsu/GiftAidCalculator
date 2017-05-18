using GiftAidCalculator.TestConsole;
using GiftAidCalculator.TestConsole.Models;
using NUnit.Framework;
using System;

namespace GiftAidCalculator.Tests
{

    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator(new User());
        }

        [Test]
        [TestCase(null)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Calculate_DefaultInvalidAmount_ShouldReturnThrowException(decimal amount)
        {
            //When Then
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Calculate(amount));
            Assert.AreEqual("amount should be grater than 0", exception.Message);
        }

        [Test]
        public void Calculate_DefaultTaxRate_ShouldReturnRoundResult()
        {
            //When
            var result = _calculator.Calculate(40.2m);

            //Then
            Assert.AreEqual(10.05, result);
        }

        [Test]
        public void Calculate_DefaultTaxRate_ShouldReturnCalculatedAmount()
        {
            //When
            var result = _calculator.Calculate(100);

            //Then
            Assert.AreEqual(25, result);
        }

        [Test]
        public void ChangeTaxRate_AsAdministrator_ShouldReturnCalculatedAmount()
        {
            //Given
            _calculator.Login(new Admin());
            _calculator.ChangeTaxRate(10);

            //When
            var result = _calculator.Calculate(100);

            //Then
            Assert.AreEqual(11.11, result);
        }

        [Test]
        public void ChangeTaxRate_AsDonor_ShouldReturnNotChangeTaxRate()
        {
            //Given
            _calculator.ChangeTaxRate(1);

            //When
            var result = _calculator.Calculate(100);

            //Then
            Assert.AreEqual(25, result);
        }

        [Test]
        public void WithEvent_Running_ShouldReturnAmountWithSupplement()
        {
            //Given
            _calculator.AddEvent(new Running());

            //When
            var result = _calculator.Calculate(100);

            //Then
            Assert.AreEqual(25.75, result);
        }

        [Test]
        public void WithEvent_Swimming_ShouldReturnAmountWithSupplement()
        {
            //Given
            _calculator.AddEvent(new Swimming());

            //When
            var result = _calculator.Calculate(100);

            //Then
            Assert.AreEqual(26.25, result);
        }

        [Test]
        public void WithEvent_Default_ShouldReturnAmountWithNoSupplement()
        {
            //Given
            _calculator.AddEvent(new Event());

            //When
            var result = _calculator.Calculate(100);

            //Then
            Assert.AreEqual(25, result);
        }
    }
}

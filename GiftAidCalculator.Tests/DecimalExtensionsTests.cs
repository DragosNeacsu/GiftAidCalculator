using GiftAidCalculator.TestConsole.Extensions;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    public class DecimalExtensionsTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1.316, 1.32)]
        [TestCase(-1.316, -1.32)]
        public void RoundDecimals_ShouldRoundToTwoDecimals(decimal number, decimal expectedResult)
        {
            //When
            var result = number.RoundDecimal();

            //Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}

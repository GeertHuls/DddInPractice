using DddInPractice.Logic;
using FluentAssertions;
using Xunit;

namespace DddInPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_of_two_moneys_produce_correct_results()
        {
            //Arrange
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            //Act
            var sum = money1 + money2;

            //Assert
            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }
    }
}

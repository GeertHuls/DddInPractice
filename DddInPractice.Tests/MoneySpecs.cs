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

        [Fact]
        public void Two_money_intances_equal_if_contain_the_same_money_amount()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);
            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }

        [Fact]
        public void Two_money_instances_differ_with_other_money_amount()
        {
            var dollar = new Money(0, 0, 0, 1, 0, 0);
            var hunderedCents = new Money(100, 0, 0, 0, 0, 0);

            dollar.Should().NotBe(hunderedCents);
            dollar.GetHashCode().Should().NotBe(hunderedCents.GetHashCode());
        }
    }
}

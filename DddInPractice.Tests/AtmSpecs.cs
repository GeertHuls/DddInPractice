using DddInPractice.Logic.Atms;
using DddInPractice.Logic.SharedKernel;
using FluentAssertions;
using Xunit;

namespace DddInPractice.Tests
{
    public class AtmSpecs
    {
        [Fact]
        public void Take_money_exchanges_money_with_commision()
        {
            var atm = new Atm();
            atm.LoadMoney(Money.Dollar);

            atm.TakeMoney(1m);
            atm.MoneyInside.Amount.Should().Be(0m);
            atm.MoneyCharged.Should().Be(1.01m);
        }
    }
}
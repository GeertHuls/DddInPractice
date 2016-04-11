using DddInPractice.Logic.Atms;
using DddInPractice.Logic.Utils;
using FluentAssertions;
using NHibernate.Util;
using Xunit;
using static DddInPractice.Logic.SharedKernel.Money;

namespace DddInPractice.Tests
{
    public class AtmSpecs
    {
        [Fact]
        public void Take_money_exchanges_money_with_commision()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar);

            atm.TakeMoney(1m);
            atm.MoneyInside.Amount.Should().Be(0m);
            atm.MoneyCharged.Should().Be(1.01m);
        }

        [Fact]
        public void Commission_is_at_lease_one_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Cent);

            atm.TakeMoney(0.01m);

            atm.MoneyCharged.Should().Be(0.02m);
        }

        [Fact]
        public void Commission_is_rounded_up_to_the_next_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar + TenCent);

            atm.TakeMoney(1.1m);

            atm.MoneyCharged.Should().Be(1.12m);
        }

        [Fact(Skip = "This test integrates with a database to fetch the head office.")]
        public void Take_money_raises_an_event()
        {
            Initer.Init(@"Data Source=.\dev;Initial Catalog=SnackMachineDb;Integrated Security=SSPI;");

            var atm = new Atm();
            atm.LoadMoney(Dollar);
            atm.TakeMoney(1m);

            atm.ShouldContainBalanceChangeEvents(1.01m);
        }
    }
}
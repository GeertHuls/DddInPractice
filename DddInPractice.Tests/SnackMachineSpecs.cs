using DddInPractice.Logic;
using FluentAssertions;
using Xunit;

using static DddInPractice.Logic.Money;

namespace DddInPractice.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_empties_money_in_transaction()
        {
            var snackmachine = new SnackMachine();
            snackmachine.InsertMoney(Dollar);

            snackmachine.ReturnMoney();

            snackmachine.MoneyInTransaction.Amount.Should().Be(0);
        }
    }
}
using System;
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

        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_at_the_same_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Cent + Cent;

            Action insertAtOnce = () => snackMachine.InsertMoney(twoCent);

            insertAtOnce.ShouldThrow<InvalidOperationException>();
        }
    }
}
using System.Linq;
using DddInPractice.Logic.Atms;
using FluentAssertions;

namespace DddInPractice.Tests
{
    internal static class AtmExtensions
    {
        public static void ShouldContainBalanceChangeEvents(this Atm atm, decimal delta)
        {
            var domainEvent = (BalanceChangedEvent)atm.DomainEvents
                .SingleOrDefault(x => x.GetType() == typeof (BalanceChangedEvent));

            domainEvent.Should().NotBeNull();
            domainEvent.Delta.Should().Be(delta);
        }
    }
}
using System.Collections.Generic;
using NHibernate.Mapping;

namespace DddInPractice.Logic.Common
{
    public class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
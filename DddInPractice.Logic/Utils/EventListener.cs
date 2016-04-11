using System;
using DddInPractice.Logic.Common;
using NHibernate.Event;

namespace DddInPractice.Logic.Utils
{
    internal class EventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        public void OnPostDelete(PostDeleteEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            DispatchEvents(@event.AffectedOwnerOrNull as AggregateRoot);
        }

        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }
    }
}
﻿using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggragateId = aggregateId;
        }
    }
}

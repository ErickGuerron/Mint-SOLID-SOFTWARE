using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

using CleanTeeth.Domain.Interfaces;

public interface IMessagingService
{
    void Send(IPerson person);
}

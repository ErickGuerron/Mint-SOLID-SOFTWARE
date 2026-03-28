using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

public interface IMessagingService
{
    void Send(Patient patient);
}

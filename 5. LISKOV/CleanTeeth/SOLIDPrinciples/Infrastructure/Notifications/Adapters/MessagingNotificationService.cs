using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

using CleanTeeth.Domain.Interfaces;

public class MessagingNotificationService : INotifactionService
{
    private readonly IMessagingService _messagingService;
    public void Send(IPerson person, string message)
    {
        _messagingService.Send(person);
    }
}

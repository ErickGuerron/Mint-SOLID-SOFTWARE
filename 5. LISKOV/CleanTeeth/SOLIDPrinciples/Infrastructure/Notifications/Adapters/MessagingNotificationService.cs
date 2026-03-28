using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

public class MessagingNotificationService : INotifactionService
{
    private readonly IMessagingService _messagingService;
    public void Send(Patient patient, string message)
    {
        _messagingService.Send(patient);
    }
}

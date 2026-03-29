using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using CleanTeeth.Domain.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

public class WhatsAppMessagingService : IMessagingService
{
    public void Send(IPerson person)
    {
        Console.WriteLine($"WhatsApp enviado para: {person.Name}");
    }
}

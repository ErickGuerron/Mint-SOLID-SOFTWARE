using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

public class WhatsAppMessagingService : IMessagingService
{
    public void Send(Patient patient)
    {
        Console.WriteLine($"WhatsApp enviado para: {patient.Name}");
    }
}

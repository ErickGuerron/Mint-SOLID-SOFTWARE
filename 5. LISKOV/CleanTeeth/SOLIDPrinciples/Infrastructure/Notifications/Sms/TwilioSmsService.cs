using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

using CleanTeeth.Domain.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

public class TwilioSmsService : ISmsService
{
    public void Send(IPerson person)
    {
        // Logica de envio...
        Console.WriteLine($"SMS enviado con Twilio para: {person.Name}");
    }
}

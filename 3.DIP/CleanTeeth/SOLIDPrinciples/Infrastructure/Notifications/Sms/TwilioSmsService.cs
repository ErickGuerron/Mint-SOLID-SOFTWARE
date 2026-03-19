using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

public class TwilioSmsService : ISmsService
{
    public void Send(Patient patient)
    {
        // Logica de envio...
        Console.WriteLine($"SMS enviado con Twilio para: {patient.Name}");
    }
}

using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

public class SendGridEmailNotificationService : IEmailService
{
    public void Send(Email email)
    {
        Console.WriteLine($"Email enviado con SendGrid para: {email.Value}");
    }
}

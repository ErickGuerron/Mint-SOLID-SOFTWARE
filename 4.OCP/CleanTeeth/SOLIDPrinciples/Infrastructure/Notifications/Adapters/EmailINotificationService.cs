using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

public class EmailINotificationService : INotifactionService
{
    private readonly IEmailService _emailService;

    //DI: Inyeccion de Dependencias.
    public EmailINotificationService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void Send(Patient patient, string message)
    {
        _emailService.Send(patient.Email);
    }
}

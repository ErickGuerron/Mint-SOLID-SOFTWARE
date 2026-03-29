using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Sms;
using System;
using System.Collections.Generic;
using System.Text;

using CleanTeeth.Domain.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

internal class SmsNotificationService : INotifactionService
{
    private readonly ISmsService _smsService;
    public SmsNotificationService(ISmsService smsService)
    {
        _smsService = smsService;
    }
    public void Send(IPerson person, string message)
    {
        _smsService.Send(person);
    }
}

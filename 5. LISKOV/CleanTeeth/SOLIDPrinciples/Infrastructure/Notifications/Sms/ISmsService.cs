using CleanTeeth.Domain.Entities;

using CleanTeeth.Domain.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

public interface ISmsService
{
    void Send(IPerson person);
}

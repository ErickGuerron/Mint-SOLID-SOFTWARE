using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Application.Interfaces;

using CleanTeeth.Domain.Interfaces;

public interface INotifactionService
{
    void Send(IPerson person, string message);
}

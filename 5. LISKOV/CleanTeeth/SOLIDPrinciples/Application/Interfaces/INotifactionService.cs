using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples.Application.Interfaces;

public interface INotifactionService
{
    void Send(Patient patient, string message);
}

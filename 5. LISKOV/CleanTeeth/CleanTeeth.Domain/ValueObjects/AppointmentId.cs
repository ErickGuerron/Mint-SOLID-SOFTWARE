using System;

namespace CleanTeeth.Domain.ValueObjects;

public record AppointmentId(Guid Value)
{
    public static AppointmentId New() => new(Guid.NewGuid());
}

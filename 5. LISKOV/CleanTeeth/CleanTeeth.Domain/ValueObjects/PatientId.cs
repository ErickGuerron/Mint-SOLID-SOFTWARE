using System;

namespace CleanTeeth.Domain.ValueObjects;

public record PatientId(Guid Value)
{
    public static PatientId New() => new(Guid.NewGuid());
}

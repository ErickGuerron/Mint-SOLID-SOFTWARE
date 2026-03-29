using System;

namespace CleanTeeth.Domain.ValueObjects;

public record DentistId(Guid Value)
{
    public static DentistId New() => new(Guid.NewGuid());
}

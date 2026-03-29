using System;

namespace CleanTeeth.Domain.ValueObjects;

public record DentalOfficeId(Guid Value)
{
    public static DentalOfficeId New() => new(Guid.NewGuid());
}

using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class DentalOffice : Entity<DentalOfficeId>
{
    public Name Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public PhoneNumber PhoneNumber { get; private set; } = null!;

    private DentalOffice() { } // Para ORMs

    public DentalOffice(DentalOfficeId id, Name name, Address address, PhoneNumber phoneNumber)
    {
        if (id is null) throw new BusinessRuleException($"El ID es requerido");
        if (name is null) throw new BusinessRuleException($"El nombre es requerido");
        if (address is null) throw new BusinessRuleException($"La dirección es requerida");
        if (phoneNumber is null) throw new BusinessRuleException($"El teléfono es requerido");

        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}


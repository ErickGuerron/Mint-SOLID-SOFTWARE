using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Patient : Person<PatientId>
{
    public Address Address { get; private set; } = null!;

    private Patient() : base() { }

    public Patient(PatientId id, Name name, Email email, PhoneNumber phoneNumber, Address address)
        : base(id, name, email, phoneNumber)
    {
        if (address is null) throw new BusinessRuleException($"La dirección es requerida");
        Address = address;
    }
}

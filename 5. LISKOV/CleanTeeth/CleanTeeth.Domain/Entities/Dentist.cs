using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public class Dentist : Person<DentistId>
{
    private Dentist() : base() { }

    public Dentist(DentistId id, Name name, Email email, PhoneNumber phoneNumber)
        : base(id, name, email, phoneNumber)
    {
    }
}


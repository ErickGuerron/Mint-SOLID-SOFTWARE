using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.Interfaces;
using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Entities;

public abstract class Person<TId> : Entity<TId>, IPerson where TId : notnull
{
    public Name Name { get; protected set; } = null!;
    public Email Email { get; protected set; } = null!;
    public PhoneNumber PhoneNumber { get; protected set; } = null!;

    protected Person() { } // Para ORMs

    protected Person(TId id, Name name, Email email, PhoneNumber phoneNumber)
    {
        if (id is null) throw new BusinessRuleException($"El ID es requerido");
        if (name is null) throw new BusinessRuleException($"El nombre es requerido");
        if (email is null) throw new BusinessRuleException($"El email es requerido");
        if (phoneNumber is null) throw new BusinessRuleException($"El teléfono es requerido");

        Id = id;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}

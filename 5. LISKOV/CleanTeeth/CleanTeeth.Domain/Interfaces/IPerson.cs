using CleanTeeth.Domain.ValueObjects;

namespace CleanTeeth.Domain.Interfaces;

public interface IPerson 
{
    Name Name { get; }
    Email Email { get; }
    PhoneNumber PhoneNumber { get; }
}

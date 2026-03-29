using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.ValueObjects;

public record Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    public Address(string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new BusinessRuleException("La calle de la dirección es requerida");
        
        if (string.IsNullOrWhiteSpace(city))
            throw new BusinessRuleException("La ciudad de la dirección es requerida");
            
        if (string.IsNullOrWhiteSpace(state))
            throw new BusinessRuleException("El estado/provincia de la dirección es requerido");
            
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new BusinessRuleException("El código postal es requerido");

        Street = street.Trim();
        City = city.Trim();
        State = state.Trim();
        ZipCode = zipCode.Trim();
    }
}

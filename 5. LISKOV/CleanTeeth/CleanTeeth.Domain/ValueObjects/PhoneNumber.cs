using CleanTeeth.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace CleanTeeth.Domain.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new BusinessRuleException("El número de teléfono es requerido");
        }

        // Validación simple: mínimo 7 dígitos, máximo 15, permitiendo el signo '+' opcional al inicio.
        var cleaned = value.Trim();
        if (!Regex.IsMatch(cleaned, @"^\+?[0-9]{7,15}$"))
        {
            throw new BusinessRuleException("Formato de número de teléfono inválido");
        }

        Value = cleaned;
    }
}

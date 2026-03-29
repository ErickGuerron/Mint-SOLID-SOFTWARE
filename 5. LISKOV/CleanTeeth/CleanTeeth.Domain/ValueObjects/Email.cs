using CleanTeeth.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace CleanTeeth.Domain.ValueObjects;

public record Email
{
    public string Value { get; } = null!;

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} es requerido");
        }

        var cleaned = email.Trim();
        if (!Regex.IsMatch(cleaned, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new BusinessRuleException($"El {nameof(email)} no es válido");
        }

        Value = cleaned;
    }
}

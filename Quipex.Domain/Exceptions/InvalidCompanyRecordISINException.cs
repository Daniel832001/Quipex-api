using Quipex.Domain.Exceptions.Parent;

namespace Quipex.Domain.Exceptions;

public class InvalidCompanyRecordISINException : DomainBadRequestException
{
    public InvalidCompanyRecordISINException(string Isin)
        : base($"'{Isin}' is not a valid ISIN. ISIN must not start with 2 numbers and must be 12 characters long.")
    {
    }
}

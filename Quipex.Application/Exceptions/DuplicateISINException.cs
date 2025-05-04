using Quipex.Application.Exceptions.Parent;

namespace Quipex.Application.Exceptions;

public class DuplicateISINException : ConflictException
{
    public DuplicateISINException(string Isin)
        : base($"A Company record with ISIN '{Isin}' already exists. Duplicate ISIN can't be added")
    {
    }
}

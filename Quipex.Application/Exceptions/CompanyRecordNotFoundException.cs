using Quipex.Application.Exceptions.Parent;

namespace Quipex.Application.Exceptions;

public class CompanyRecordNotFoundException : NotFoundException
{
    public CompanyRecordNotFoundException(long id)
        : base($"Company record with ID '{id}' was not found.")
    {
    }
}

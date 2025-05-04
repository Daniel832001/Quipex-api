namespace Quipex.Domain.Exceptions.Parent;

public class DomainBadRequestException : Exception
{
    public DomainBadRequestException(string message) : base(message)
    {
    }
}

namespace Quipex.Application.Exceptions.Parent;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}

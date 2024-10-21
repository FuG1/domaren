namespace domaren.realstate.Domain.Exceptions;

public abstract class BaseBusinessException : Exception
{
    protected BaseBusinessException(string message) : base(message) { }
}
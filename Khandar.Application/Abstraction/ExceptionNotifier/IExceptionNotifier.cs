namespace Khandar.Application.Abstractions.ExceptionNotifier;

public interface IExceptionNotifier
{
    void LogToEmail(Exception ex);
}

namespace Blazor_Server_Template.Services.Logger
{
    public interface ILogger
    {
        void Log(LogLevel logLevel, string message);
        void Log(LogLevel logLevel, string message, Exception exception);
    }
}

using log4net;

namespace Blazor_Server_Template.Logger
{
    public class Log4netLogger : ILogger
    {
        private readonly ILog _logger = LogManager.GetLogger("*");

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            
        }
    }
}

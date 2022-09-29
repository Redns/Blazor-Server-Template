using log4net;
using ILogger = Blazor_Server_Template.Services.Logger.ILogger;

namespace Blazor_Server_Template.Logger
{
    public class Log4netLogger : ILogger
    {
        /// <summary>
        /// 日志输出器
        /// </summary>
        private readonly ILog _logger;

        /// <summary>
        /// 日志输出委托
        /// </summary>
        public Action<LogLevel, string, Exception?> LogEvent { get; init; } = (level, message, e) => { };


        /// <summary>
        /// 构造 Log4net 日志输出器
        /// </summary>
        /// <param name="configFilePath">配置文件路径</param>
        /// <param name="loggerName"></param>
        public Log4netLogger(string configFilePath = "log4net.config", string loggerName = "default")
        {
            // 加载配置文件
            log4net.Config.XmlConfigurator.Configure(configFile: new FileInfo(configFilePath));

            // 获取 ILog 对象
            _logger = LogManager.GetLogger(loggerName); 
        }


        /// <summary>
        /// 输出日志（不打印异常信息）
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        public void Log(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Critical: _logger.Fatal(message); break;
                case LogLevel.Error: _logger.Error(message); break;
                case LogLevel.Warning: _logger.Warn(message); break;
                case LogLevel.Information: _logger.Info(message); break;
                default: _logger.DebugFormat(message); break;
            }
            LogEvent(logLevel, message, null);
        }


        /// <summary>
        /// 输出日志（打印异常信息）
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Log(LogLevel logLevel, string message, Exception exception)
        {
            switch (logLevel)
            {
                case LogLevel.Critical: _logger.Fatal(message, exception); break;
                case LogLevel.Error: _logger.Error(message, exception); break;
                case LogLevel.Warning: _logger.Warn(message, exception); break;
                case LogLevel.Information: _logger.Info(message, exception); break;
                default: _logger.DebugFormat(message, exception); break;
            }
            LogEvent(logLevel, message, exception);
        }
    }
}

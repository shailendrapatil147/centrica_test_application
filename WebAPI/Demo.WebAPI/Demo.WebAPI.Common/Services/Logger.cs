using NLog;

namespace Demo.WebAPI.Common.Services
{
    public class Logger : ILogger
    {
        public static NLog.ILogger _logger = LogManager.GetCurrentClassLogger(); 

        public void LogError(string Error)
        {
            _logger.Error($"Error: {Error}");
        }

        public void LogError(Exception exception)
        {
            _logger.Error(exception, exception.Message);
        }

        public void LogInfo(string Info)
        {
            _logger.Info(Info);
        }

        public void LogDebug(string Message)
        {
            _logger.Debug(Message);
        }

        public void LogWarning(string Warning)
        {
            _logger.Warn(Warning);
        }
    }
}

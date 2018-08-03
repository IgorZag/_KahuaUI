using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigration
{
    public interface ILoggingService
    {
    }

    public sealed class LoggingService : ILoggingService
    {
        readonly Log4NetLogger _logger;

        LoggingService(Log4NetLogger logger)
        {
            _logger = logger;
        }

        public static ILoggingService GetLoggingService()
        {
            return Nested.instance;
        }

        static class Nested
        {
            internal static readonly ILoggingService instance = new LoggingService(new Log4NetLogger());
        }
    }

    public interface ILogger
    {
    }

    public class Log4NetLogger : ILogger
    {
    }
}

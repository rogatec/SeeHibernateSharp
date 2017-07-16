using static SeeHibernateSharp.Libraries.Logging.LogEntry;

namespace SeeHibernateSharp.Libraries.Logging
{
    class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog adapter;
        public Log4NetAdapter(log4net.ILog adapter)
        {
            this.adapter = adapter;
        }
        public void Log(LogEntry entry)
        {
            if (entry.severity == LoggingEventType.Debug)
                adapter.Debug(entry.message, entry.exception);
            if (entry.severity == LoggingEventType.Information)
                adapter.Info(entry.message, entry.exception);
            else if (entry.severity == LoggingEventType.Warning)
                adapter.Warn(entry.message, entry.exception);
            else if (entry.severity == LoggingEventType.Error)
                adapter.Error(entry.message, entry.exception);
            else
                adapter.Fatal(entry.message, entry.exception);
        }
    }
}

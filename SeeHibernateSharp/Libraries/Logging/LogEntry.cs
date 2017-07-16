using System;

namespace SeeHibernateSharp.Libraries.Logging
{
    public class LogEntry
    {
        public enum LoggingEventType
        {
            Debug,
            Information,
            Warning,
            Error,
            Fatal
        };

        public readonly LoggingEventType severity;
        public readonly string message;
        public readonly Exception exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            string.IsNullOrEmpty(message);
            Enum.IsDefined(typeof(LoggingEventType), severity);
            this.severity = severity;
            this.message = message;
            this.exception = exception;
        }            
    }
}

using Microsoft.Extensions.Logging;
using static System.Console;

namespace Packt.Shared
{
    /// <summary>
    /// This class implement the ILoggerProvider interface.
    /// It returns an instance of ConsoleLogger.
    /// </summary>
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            // we could have a different logger implementation for
            // different categoryName values
            return new ConsoleLogger();
        }

        /// <summary>
        /// If our logger uses unmanaged resources,
        /// then we can release them here
        /// </summary>        
        public void Dispose()
        { }
    }

    /// <summary>
    /// This class implements the ILogger interface.
    /// It's disabled for log levels None, Trace and Information.
    /// It is enabled for all other log levels.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// If our Logger uses unmanaged resources, we can
        /// return the class that implements IDisposable here
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>        
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // to avoid overloading, we can filter on the log level
            return logLevel switch
            {
                _ when logLevel == LogLevel.Trace ||
                       logLevel == LogLevel.Information ||
                       logLevel == LogLevel.None => false,
                _ when logLevel == LogLevel.Debug ||
                        logLevel == LogLevel.Warning ||
                        logLevel == LogLevel.Error ||
                        logLevel == LogLevel.Critical => true,
                _ => true
            };
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {

            if (eventId.Id == 20100)
            {
                // log the level and event identifier
                Write($"Level: {logLevel}, Event Id: {eventId.Id}");

                // only output the state or exception if it exists
                if (state != null)
                {
                    Write($", State: {state}");
                }

                if (exception != null)
                {
                    Write($", Exception: {exception.Message}");
                }

                WriteLine();
            }
        }
    }
}

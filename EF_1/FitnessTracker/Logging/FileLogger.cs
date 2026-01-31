using Microsoft.Extensions.Logging;

namespace FitnessTracker.Logging;

public class FileLogger : ILogger
{
	private readonly string _logPath;
	private readonly string _categoryName;
	private readonly LogLevel _minLogLevel;

	public FileLogger(string logPath, string categoryName, LogLevel minLogLevel = LogLevel.Information)
	{
		_logPath = logPath;
		_categoryName = categoryName;
		_minLogLevel = minLogLevel;
	}

	IDisposable ILogger.BeginScope<TState>(TState state) => NoopDisposable.Instance;

	public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLogLevel;

	public void Log<TState>(
			LogLevel logLevel,
			EventId eventId,
			TState state,
			Exception? exception,
			Func<TState, Exception?, string> formatter)
	{
		if (!IsEnabled(logLevel))
			return;

		var logMessage = FormatLogMessage(logLevel, _categoryName, eventId, formatter(state, exception), exception);

		WriteToFile(logMessage);
	}

	private string FormatLogMessage(
			LogLevel logLevel,
			string categoryName,
			EventId eventId,
			string message,
			Exception? exception)
	{
		var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
		var logLevelString = logLevel.ToString().ToUpper();

		var logEntry = $"{timestamp} [{logLevelString:8}] {categoryName}";

		if (eventId.Id != 0)
		{
			logEntry += $" (EventId: {eventId.Id})";
		}

		logEntry += $": {message}";

		if (exception != null)
		{
			logEntry += Environment.NewLine + exception;
		}

		return logEntry;
	}

	private void WriteToFile(string message)
	{
		try
		{
			if (!Directory.Exists(_logPath))
			{
				Directory.CreateDirectory(_logPath);
			}

			var logFileName = $"{DateTime.Now:yyyy-MM-dd}.log";
			var logFilePath = Path.Combine(_logPath, logFileName);

			lock (this)
			{
				File.AppendAllText(logFilePath, message + Environment.NewLine);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error writing to log file: {ex.Message}");
		}
	}

	private class NoopDisposable : IDisposable
	{
		public static readonly NoopDisposable Instance = new();

		public void Dispose()
		{
		}
	}
}

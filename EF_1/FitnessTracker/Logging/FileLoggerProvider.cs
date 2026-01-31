using Microsoft.Extensions.Logging;

namespace FitnessTracker.Logging;

public class FileLoggerProvider : ILoggerProvider
{
	private readonly string _logPath;
	private readonly LogLevel _minLogLevel;

	public FileLoggerProvider(string logPath, LogLevel minLogLevel = LogLevel.Information)
	{
		_logPath = logPath;
		_minLogLevel = minLogLevel;
	}

	public ILogger CreateLogger(string categoryName)
	{
		return new FileLogger(_logPath, categoryName, _minLogLevel);
	}

	public void Dispose()
	{
	}
}

namespace FitnessTracker.Presentation;

public static class LoggerHelper
{
	private static readonly string _logsDir = "Logs";
	private static readonly string _logFile;

	static LoggerHelper()
	{

		if (!Directory.Exists(_logsDir))
			Directory.CreateDirectory(_logsDir);

		string dateFileName = DateTime.Now.ToString("yyyy-MM-dd");
		_logFile = Path.Combine(_logsDir, $"fitness_tracker_{dateFileName}.log");
	}

	public static void Log(string message)
	{
		var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		var logMessage = $"[{timestamp}] {message}";

		Console.ForegroundColor = ConsoleColor.DarkGray;
		Console.WriteLine($"{logMessage}");
		Console.ResetColor();

		WriteToFile(logMessage);
	}

	public static void LogSuccess(string message)
	{
		var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		var logMessage = $"[{timestamp}] УСПЕШНО: {message}";

		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(logMessage);
		Console.ResetColor();

		WriteToFile(logMessage);
	}

	public static void LogError(string message)
	{
		var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		var logMessage = $"[{timestamp}] ОШИБКА: {message}";

		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(logMessage);
		Console.ResetColor();

		WriteToFile(logMessage);
	}

	private static void WriteToFile(string message)
	{
		try
		{
			File.AppendAllText(_logFile, message + Environment.NewLine);
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Log write failed: {ex.Message}");
			Console.ResetColor();
		}
	}

	public static string GetLogFilePath() => _logFile;
}


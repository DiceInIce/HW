using Microsoft.Extensions.Configuration;

namespace FitnessTracker.Configuration;

public class AppConfiguration
{
	private readonly IConfigurationRoot _configuration;

	public string FitnessTrackerConnectionString { get; }
	public string FitnessTrackerTestConnectionString { get; }
	public int MaxRetryCount { get; }
	public int CommandTimeout { get; }
	public int MaxRetryDelaySeconds { get; }
	public string LogLevel { get; }
	public bool LogDatabaseCommands { get; }
	public bool LogParameterValues { get; }
	public bool EnableDetailedErrors { get; }
	public string LogPath { get; }
	public int PageSize { get; }
	public bool EnableNotifications { get; }
	public string DateFormat { get; }

	public AppConfiguration()
	{
		var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

		var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

		_configuration = builder.Build();

		// Load connection strings
		FitnessTrackerConnectionString = _configuration.GetConnectionString("FitnessTracker")
				?? throw new InvalidOperationException("Connection string 'FitnessTracker' not found in configuration");
		FitnessTrackerTestConnectionString = _configuration.GetConnectionString("FitnessTrackerTest")
				?? throw new InvalidOperationException("Connection string 'FitnessTrackerTest' not found in configuration");

		// Load database settings
		MaxRetryCount = _configuration.GetValue("DatabaseSettings:MaxRetryCount", 3);
		CommandTimeout = _configuration.GetValue("DatabaseSettings:CommandTimeout", 30);
		MaxRetryDelaySeconds = _configuration.GetValue("DatabaseSettings:MaxRetryDelaySeconds", 30);

		// Load logging settings
		LogLevel = _configuration.GetValue("LoggingSettings:LogLevel", "Information");
		LogDatabaseCommands = _configuration.GetValue("LoggingSettings:LogDatabaseCommands", false);
		LogParameterValues = _configuration.GetValue("LoggingSettings:LogParameterValues", false);
		EnableDetailedErrors = _configuration.GetValue("LoggingSettings:EnableDetailedErrors", false);
		LogPath = _configuration.GetValue("LoggingSettings:LogPath", "Logs");

		// Load app settings
		PageSize = _configuration.GetValue("AppSettings:PageSize", 10);
		EnableNotifications = _configuration.GetValue("AppSettings:EnableNotifications", false);
		DateFormat = _configuration.GetValue("AppSettings:DateFormat", "yyyy-MM-dd HH:mm:ss");

		// Create Logs directory if it doesn't exist
		if (!Directory.Exists(LogPath))
		{
			Directory.CreateDirectory(LogPath);
		}
	}

	public IConfigurationRoot GetConfiguration() => _configuration;
}

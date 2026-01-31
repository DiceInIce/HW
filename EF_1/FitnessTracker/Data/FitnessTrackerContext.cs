using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FitnessTracker.Models;
using FitnessTracker.Data.Configuration;
using FitnessTracker.Configuration;
using FitnessTracker.Logging;

namespace FitnessTracker.Data;

public class FitnessTrackerContext : DbContext
{
	private readonly AppConfiguration _appConfiguration;
	private readonly ILoggerFactory _loggerFactory;

	public DbSet<Exercise> Exercises { get; set; }
	public DbSet<Client> Clients { get; set; }
	public DbSet<Trainer> Trainers { get; set; }
	public DbSet<WorkoutSession> WorkoutSessions { get; set; }
	public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

	public FitnessTrackerContext(AppConfiguration appConfiguration)
	{
		_appConfiguration = appConfiguration;
		_loggerFactory = LoggerFactory.Create(builder =>
		{
			builder.AddProvider(new FileLoggerProvider(
				appConfiguration.LogPath,
				Enum.Parse<LogLevel>(appConfiguration.LogLevel)
			));
			builder.AddConsole();
		});
	}

	public FitnessTrackerContext() : this(new AppConfiguration())
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			var connectionString = _appConfiguration.FitnessTrackerConnectionString;

			optionsBuilder.UseNpgsql(connectionString, options =>
			{
				options.EnableRetryOnFailure(
					maxRetryCount: _appConfiguration.MaxRetryCount,
					maxRetryDelay: TimeSpan.FromSeconds(_appConfiguration.MaxRetryDelaySeconds),
					errorCodesToAdd: null
				);
				options.CommandTimeout(_appConfiguration.CommandTimeout);
			})
			.UseLoggerFactory(_loggerFactory);

			if (_appConfiguration.LogDatabaseCommands)
			{
				optionsBuilder.LogTo(Console.WriteLine, 
					new[] { DbLoggerCategory.Database.Command.Name },
					LogLevel.Information);
			}

			if (_appConfiguration.EnableDetailedErrors)
			{
				optionsBuilder.EnableDetailedErrors();
			}
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Create schema
		modelBuilder.HasDefaultSchema("fitness");

		// Apply configurations
		modelBuilder.ApplyConfiguration(new ClientConfiguration());
		modelBuilder.ApplyConfiguration(new TrainerConfiguration());
		modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
		modelBuilder.ApplyConfiguration(new WorkoutSessionConfiguration());
		modelBuilder.ApplyConfiguration(new WorkoutExerciseConfiguration());

		// Global query filters - only active memberships
		modelBuilder.Entity<Client>()
			.HasQueryFilter(c => c.MembershipType != "Неактивный");
	}
}


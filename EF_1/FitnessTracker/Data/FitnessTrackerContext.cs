using Microsoft.EntityFrameworkCore;
using FitnessTracker.Models;
using dotenv.net;

namespace FitnessTracker.Data;

public class FitnessTrackerContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<WorkoutSession> WorkoutSessions { get; set; }

    public FitnessTrackerContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DotEnv.Load();
        
        var host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
        var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "FitnessTrackerDB";
        var user = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";

        var connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password}";
        
        optionsBuilder.UseNpgsql(connectionString);
    }
}


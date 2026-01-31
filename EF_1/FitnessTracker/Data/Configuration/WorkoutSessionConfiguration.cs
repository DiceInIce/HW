using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FitnessTracker.Models;

namespace FitnessTracker.Data.Configuration;

public class WorkoutSessionConfiguration : IEntityTypeConfiguration<WorkoutSession>
{
	public void Configure(EntityTypeBuilder<WorkoutSession> builder)
	{
		builder.ToTable("WorkoutSessions", "fitness");

		builder.HasKey(w => w.Id);

		builder.Property(w => w.Date)
				.IsRequired()
				.HasColumnType("timestamp")
				.HasDefaultValueSql("CURRENT_TIMESTAMP");

		builder.Property(w => w.DurationMinutes)
				.IsRequired()
				.HasDefaultValue(0);

		builder.Property(w => w.CaloriesBurned)
				.IsRequired()
				.HasDefaultValue(0);

		builder.Property(w => w.SessionType)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnType("varchar(50)")
				.HasDefaultValue("Обычная");

		// Indexes
		builder.HasIndex(w => w.Date).HasDatabaseName("idx_session_date");
		builder.HasIndex(w => w.SessionType).HasDatabaseName("idx_session_type");

		// Foreign key properties
		builder.Property(w => w.ClientId)
			.HasColumnType("integer");

		builder.Property(w => w.TrainerId)
			.HasColumnType("integer");

		// Relationship: One-to-Many with WorkoutExercise
		builder.HasMany(w => w.WorkoutExercises)
			.WithOne(we => we.WorkoutSession)
			.HasForeignKey(we => we.WorkoutSessionId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}

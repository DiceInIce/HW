using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FitnessTracker.Models;

namespace FitnessTracker.Data.Configuration;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
	public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
	{
		builder.ToTable("WorkoutExercises", "fitness");

		builder.HasKey(we => we.Id);

		// Foreign key properties
		builder.Property(we => we.WorkoutSessionId)
			.IsRequired()
			.HasColumnType("integer");

		builder.Property(we => we.ExerciseId)
			.IsRequired()
			.HasColumnType("integer");

		builder.Property(we => we.Sets)
			.IsRequired()
			.HasDefaultValue(0);

		builder.Property(we => we.Repetitions)
			.IsRequired()
			.HasDefaultValue(0);

		builder.Property(we => we.Weight)
			.HasColumnType("decimal(5,2)");

		// Relationships
		builder.HasOne(we => we.WorkoutSession)
			.WithMany(w => w.WorkoutExercises)
			.HasForeignKey(we => we.WorkoutSessionId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(we => we.Exercise)
			.WithMany(e => e.WorkoutExercises)
			.HasForeignKey(we => we.ExerciseId)
			.OnDelete(DeleteBehavior.Cascade);

		// Unique index on WorkoutSessionId + ExerciseId
		builder.HasIndex(we => new { we.WorkoutSessionId, we.ExerciseId })
			.HasDatabaseName("idx_workout_exercise_unique")
			.IsUnique();
	}
}

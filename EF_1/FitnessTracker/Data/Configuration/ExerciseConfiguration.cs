using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FitnessTracker.Models;

namespace FitnessTracker.Data.Configuration;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
	public void Configure(EntityTypeBuilder<Exercise> builder)
	{
		builder.ToTable("Exercises", "fitness");

		builder.HasKey(e => e.Id);

		builder.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

		builder.Property(e => e.DifficultyLevel)
				.IsRequired()
				.HasMaxLength(20)
				.HasColumnType("varchar(20)")
				.HasDefaultValue("Средний");

		builder.Property(e => e.EquipmentRequired)
				.HasMaxLength(200)
				.HasColumnType("varchar(200)");

		builder.Property(e => e.TargetMuscleGroup)
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

		// Indexes
		builder.HasIndex(e => e.Name).HasDatabaseName("idx_exercise_name");
		builder.HasIndex(e => e.DifficultyLevel).HasDatabaseName("idx_exercise_difficulty");
		builder.HasIndex(e => e.TargetMuscleGroup).HasDatabaseName("idx_exercise_muscle");

		// Relationship: One-to-Many with WorkoutExercise
		builder.HasMany(e => e.WorkoutExercises)
			.WithOne(we => we.Exercise)
			.HasForeignKey(we => we.ExerciseId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}

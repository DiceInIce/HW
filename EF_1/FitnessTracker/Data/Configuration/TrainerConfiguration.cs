using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FitnessTracker.Models;

namespace FitnessTracker.Data.Configuration;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
	public void Configure(EntityTypeBuilder<Trainer> builder)
	{
		builder.ToTable("Trainers", "fitness");

		builder.HasKey(t => t.Id);

		builder.Property(t => t.FullName)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

		builder.Property(t => t.Specialization)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnType("varchar(50)");

		builder.Property(t => t.ExperienceYears)
				.IsRequired()
				.HasDefaultValue(0);

		builder.Property(t => t.PhoneNumber)
				.IsRequired()
				.HasMaxLength(20)
				.HasColumnType("varchar(20)");

		// Indexes
		builder.HasIndex(t => t.FullName).HasDatabaseName("idx_trainer_fullname");
		builder.HasIndex(t => t.Specialization).HasDatabaseName("idx_trainer_specialization");
		builder.HasIndex(t => t.PhoneNumber).HasDatabaseName("idx_trainer_phone").IsUnique();

		// Relationship: One-to-Many with WorkoutSession
		builder.HasMany(t => t.WorkoutSessions)
			.WithOne(w => w.Trainer)
			.HasForeignKey(w => w.TrainerId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}

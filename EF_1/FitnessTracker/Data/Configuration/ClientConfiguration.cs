using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FitnessTracker.Models;

namespace FitnessTracker.Data.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
	public void Configure(EntityTypeBuilder<Client> builder)
	{
		builder.ToTable("Clients", "fitness");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.FullName)
			.IsRequired()
			.HasMaxLength(100)
			.HasColumnType("varchar(100)");

		builder.Property(c => c.BirthDate)
			.IsRequired()
			.HasColumnType("date");

		builder.Property(c => c.MembershipType)
			.IsRequired()
			.HasMaxLength(20)
			.HasColumnType("varchar(20)")
			.HasDefaultValue("Разовый");

		builder.Property(c => c.RegistrationDate)
			.IsRequired()
			.HasColumnType("timestamp")
			.HasDefaultValueSql("CURRENT_TIMESTAMP");

		// Add email property
		builder.Property(c => c.Email)
			.HasMaxLength(100)
			.HasColumnType("varchar(100)");

		// Indexes
		builder.HasIndex(c => c.FullName).HasDatabaseName("idx_client_fullname");
		builder.HasIndex(c => c.Email).HasDatabaseName("idx_client_email").IsUnique();
		builder.HasIndex(c => c.MembershipType).HasDatabaseName("idx_client_membership");
	}
}

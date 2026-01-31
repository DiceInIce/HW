using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitnessTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fitness");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "fitness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    MembershipType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Разовый"),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                schema: "fitness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DifficultyLevel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValue: "Средний"),
                    EquipmentRequired = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TargetMuscleGroup = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                schema: "fitness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ExperienceYears = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                schema: "fitness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CaloriesBurned = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    SessionType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Обычная")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_client_fullname",
                schema: "fitness",
                table: "Clients",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "idx_client_membership",
                schema: "fitness",
                table: "Clients",
                column: "MembershipType");

            migrationBuilder.CreateIndex(
                name: "idx_exercise_difficulty",
                schema: "fitness",
                table: "Exercises",
                column: "DifficultyLevel");

            migrationBuilder.CreateIndex(
                name: "idx_exercise_muscle",
                schema: "fitness",
                table: "Exercises",
                column: "TargetMuscleGroup");

            migrationBuilder.CreateIndex(
                name: "idx_exercise_name",
                schema: "fitness",
                table: "Exercises",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_trainer_fullname",
                schema: "fitness",
                table: "Trainers",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "idx_trainer_phone",
                schema: "fitness",
                table: "Trainers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_trainer_specialization",
                schema: "fitness",
                table: "Trainers",
                column: "Specialization");

            migrationBuilder.CreateIndex(
                name: "idx_session_date",
                schema: "fitness",
                table: "WorkoutSessions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "idx_session_type",
                schema: "fitness",
                table: "WorkoutSessions",
                column: "SessionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "fitness");

            migrationBuilder.DropTable(
                name: "Exercises",
                schema: "fitness");

            migrationBuilder.DropTable(
                name: "Trainers",
                schema: "fitness");

            migrationBuilder.DropTable(
                name: "WorkoutSessions",
                schema: "fitness");
        }
    }
}

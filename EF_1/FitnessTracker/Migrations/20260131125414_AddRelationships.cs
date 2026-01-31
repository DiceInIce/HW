using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitnessTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                schema: "fitness",
                table: "WorkoutSessions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                schema: "fitness",
                table: "WorkoutSessions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                schema: "fitness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkoutSessionId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Sets = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Repetitions = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Weight = table.Column<decimal>(type: "numeric(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalSchema: "fitness",
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_WorkoutSessions_WorkoutSessionId",
                        column: x => x.WorkoutSessionId,
                        principalSchema: "fitness",
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_ClientId",
                schema: "fitness",
                table: "WorkoutSessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_TrainerId",
                schema: "fitness",
                table: "WorkoutSessions",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "idx_workout_exercise_unique",
                schema: "fitness",
                table: "WorkoutExercises",
                columns: new[] { "WorkoutSessionId", "ExerciseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                schema: "fitness",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_Clients_ClientId",
                schema: "fitness",
                table: "WorkoutSessions",
                column: "ClientId",
                principalSchema: "fitness",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_Trainers_TrainerId",
                schema: "fitness",
                table: "WorkoutSessions",
                column: "TrainerId",
                principalSchema: "fitness",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_Clients_ClientId",
                schema: "fitness",
                table: "WorkoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_Trainers_TrainerId",
                schema: "fitness",
                table: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "WorkoutExercises",
                schema: "fitness");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_ClientId",
                schema: "fitness",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_TrainerId",
                schema: "fitness",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "fitness",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                schema: "fitness",
                table: "WorkoutSessions");
        }
    }
}

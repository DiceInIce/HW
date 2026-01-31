using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Автосгенерированный код EF Core - добавление колонки Email
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "fitness",
                table: "Clients",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            // Создание уникального индекса для Email
            migrationBuilder.CreateIndex(
                name: "idx_client_email",
                schema: "fitness",
                table: "Clients",
                column: "Email",
                unique: true);

            // Кастомный SQL - создание VIEW для активных клиентов
            migrationBuilder.Sql(@"
        CREATE OR REPLACE VIEW fitness.ActiveClients AS
        SELECT * FROM fitness.""Clients"" 
        WHERE ""MembershipType"" IN ('Месячный', 'Годовой')
        ");

            // Кастомный SQL - создание функции для расчета возраста клиента
            migrationBuilder.Sql(@"
        CREATE OR REPLACE FUNCTION fitness.CalculateClientAge(client_id INTEGER)
        RETURNS INTEGER AS $$
        BEGIN
            RETURN EXTRACT(YEAR FROM AGE((SELECT ""BirthDate"" FROM fitness.""Clients"" WHERE ""Id"" = client_id)))::INTEGER;
        END;
        $$ LANGUAGE plpgsql;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаление функции для расчета возраста
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS fitness.CalculateClientAge(INTEGER);");

            // Удаление VIEW для активных клиентов
            migrationBuilder.Sql("DROP VIEW IF EXISTS fitness.ActiveClients;");

            // Удаление индекса Email
            migrationBuilder.DropIndex(
                name: "idx_client_email",
                schema: "fitness",
                table: "Clients");

            // Удаление колонки Email
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "fitness",
                table: "Clients");
        }
    }
}

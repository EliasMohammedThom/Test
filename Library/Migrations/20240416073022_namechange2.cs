using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class namechange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneratedWorkouts",
                table: "GeneratedWorkouts");

            migrationBuilder.RenameTable(
                name: "GeneratedWorkouts",
                newName: "GeneratedExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneratedExercises",
                table: "GeneratedExercises",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneratedExercises",
                table: "GeneratedExercises");

            migrationBuilder.RenameTable(
                name: "GeneratedExercises",
                newName: "GeneratedWorkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneratedWorkouts",
                table: "GeneratedWorkouts",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedInputValuesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DifficultyCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleCategories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfWorkouts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputValues", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputValues");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testhej : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExercisesAPIs_WorkoutId",
                table: "ExercisesAPIs",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesAPIs_Workouts_WorkoutId",
                table: "ExercisesAPIs",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesAPIs_Workouts_WorkoutId",
                table: "ExercisesAPIs");

            migrationBuilder.DropIndex(
                name: "IX_ExercisesAPIs_WorkoutId",
                table: "ExercisesAPIs");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedWorkoutandExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesAPIs_Workouts_WorkoutId",
                table: "ExercisesAPIs");

            migrationBuilder.DropIndex(
                name: "IX_ExercisesAPIs_WorkoutId",
                table: "ExercisesAPIs");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "ExercisesAPIs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "ExercisesAPIs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesAPIs_WorkoutId",
                table: "ExercisesAPIs",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesAPIs_Workouts_WorkoutId",
                table: "ExercisesAPIs",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

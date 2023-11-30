using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedListInScheduleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Schedules_ScheduleId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ScheduleId",
                table: "Workouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ScheduleId",
                table: "Workouts",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Schedules_ScheduleId",
                table: "Workouts",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }
    }
}

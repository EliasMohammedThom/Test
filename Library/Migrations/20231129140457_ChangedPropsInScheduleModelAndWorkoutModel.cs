using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPropsInScheduleModelAndWorkoutModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Workouts",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Workouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Schedules",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Workouts",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Schedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

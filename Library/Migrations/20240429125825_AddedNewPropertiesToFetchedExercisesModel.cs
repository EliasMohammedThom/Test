using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertiesToFetchedExercisesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Distance",
                table: "FetchedExercises",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "FetchedExercises",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "FetchedExercises",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "FetchedExercises");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "FetchedExercises");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "FetchedExercises");
        }
    }
}

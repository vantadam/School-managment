using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.web.Migrations
{
    /// <inheritdoc />
    public partial class NewStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscribed",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AbsenceCount",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Average",
                table: "Students",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PresenceCount",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbsenceCount",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Average",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PresenceCount",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "Subscribed",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

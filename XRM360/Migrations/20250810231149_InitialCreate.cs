using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XRM360website.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    WeChatId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreferredContact = table.Column<int>(type: "int", nullable: false),
                    StudyLevel = table.Column<int>(type: "int", nullable: false),
                    IntendedMajor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TargetStartTerm = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CurrentCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryOfCitizenship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnglishStatus = table.Column<int>(type: "int", nullable: false),
                    BudgetRangeUsd = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UtmSource = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLeads", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLeads_CreatedUtc",
                table: "StudentLeads",
                column: "CreatedUtc");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLeads_Email",
                table: "StudentLeads",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLeads");
        }
    }
}

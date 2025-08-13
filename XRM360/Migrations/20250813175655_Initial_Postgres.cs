using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XRM360website.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Postgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    WeChatId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PreferredContact = table.Column<int>(type: "integer", nullable: false),
                    StudyLevel = table.Column<int>(type: "integer", nullable: false),
                    IntendedMajor = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    TargetStartTerm = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CurrentCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CountryOfCitizenship = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    EnglishStatus = table.Column<int>(type: "integer", nullable: false),
                    BudgetRangeUsd = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    UtmSource = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

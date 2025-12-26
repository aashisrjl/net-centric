using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_4.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharacterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BirthCity = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BirthCountry = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    HeightInches = table.Column<int>(type: "INTEGER", nullable: true),
                    Biography = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    NetWorth = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieID = table.Column<int>(type: "INTEGER", nullable: false),
                    ActorID = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Pay = table.Column<double>(type: "REAL", nullable: true),
                    Screentime = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}

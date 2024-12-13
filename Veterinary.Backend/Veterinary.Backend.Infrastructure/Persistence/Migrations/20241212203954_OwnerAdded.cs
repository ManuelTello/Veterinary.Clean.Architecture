using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary.Backend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OwnerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    identification = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    date_added_to_system = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owners");
        }
    }
}

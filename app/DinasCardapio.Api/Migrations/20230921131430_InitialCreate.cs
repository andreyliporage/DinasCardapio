using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DinasCardapio.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Url = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Size = table.Column<string>(type: "VARCHAR", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Product",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Token.Infra.Data.Migrations
{
    public partial class TokenDBV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CVV = table.Column<int>(type: "Int", nullable: false),
                    CardNumber = table.Column<long>(type: "BigInt", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Date);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Token.Infra.Data.Migrations
{
    public partial class TokenDBV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Token");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Token",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "Token",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Token",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Token",
                nullable: false,
                defaultValue: "");
        }
    }
}

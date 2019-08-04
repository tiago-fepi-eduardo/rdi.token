using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Token.Infra.Data.Migrations
{
    public partial class TokenDBV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Token",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "ID");
        }
    }
}

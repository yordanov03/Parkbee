using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parkbee.Infrastructure.Migrations
{
    public partial class AuditGarage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Garages",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Garages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Garages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Garages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Garages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Doors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "Doors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Doors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "Doors",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "Doors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Garages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(280)",
                oldMaxLength: 280);
        }
    }
}

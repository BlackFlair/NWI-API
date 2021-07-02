using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookFinderAPI.Migrations
{
    public partial class BookFinderCompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfPublication",
                table: "BookFinderModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "BookFinderModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "publisher",
                table: "BookFinderModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateOfPublication",
                table: "BookFinderModel");

            migrationBuilder.DropColumn(
                name: "genre",
                table: "BookFinderModel");

            migrationBuilder.DropColumn(
                name: "publisher",
                table: "BookFinderModel");
        }
    }
}

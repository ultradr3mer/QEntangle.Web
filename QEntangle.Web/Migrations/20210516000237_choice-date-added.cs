using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QEntangle.Web.Migrations
{
    public partial class choicedateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Choice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EvaluatedDate",
                table: "Choice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Choice");

            migrationBuilder.DropColumn(
                name: "EvaluatedDate",
                table: "Choice");
        }
    }
}

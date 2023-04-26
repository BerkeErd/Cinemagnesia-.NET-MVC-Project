using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    public partial class Productor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductorRequests_Companies_CompanyId",
                table: "ProductorRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProductorRequests_CompanyId",
                table: "ProductorRequests");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProductorRequests");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "ProductorRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundDate",
                table: "ProductorRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TaxNumber",
                table: "ProductorRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "ProductorRequests");

            migrationBuilder.DropColumn(
                name: "FoundDate",
                table: "ProductorRequests");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "ProductorRequests");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "ProductorRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductorRequests_CompanyId",
                table: "ProductorRequests",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductorRequests_Companies_CompanyId",
                table: "ProductorRequests",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

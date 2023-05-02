using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    public partial class Validations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_UserLikesId",
                table: "ApplicationUserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserMovie_UserLikesId",
                table: "ApplicationUserMovie");

            migrationBuilder.RenameColumn(
                name: "UserLikesId",
                table: "ApplicationUserMovie",
                newName: "LikedUsersId");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie",
                columns: new[] { "LikedUsersId", "RatedMoviesId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMovie_RatedMoviesId",
                table: "ApplicationUserMovie",
                column: "RatedMoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_LikedUsersId",
                table: "ApplicationUserMovie",
                column: "LikedUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_LikedUsersId",
                table: "ApplicationUserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserMovie_RatedMoviesId",
                table: "ApplicationUserMovie");

            migrationBuilder.RenameColumn(
                name: "LikedUsersId",
                table: "ApplicationUserMovie",
                newName: "UserLikesId");

            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "Ratings",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie",
                columns: new[] { "RatedMoviesId", "UserLikesId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMovie_UserLikesId",
                table: "ApplicationUserMovie",
                column: "UserLikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_UserLikesId",
                table: "ApplicationUserMovie",
                column: "UserLikesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

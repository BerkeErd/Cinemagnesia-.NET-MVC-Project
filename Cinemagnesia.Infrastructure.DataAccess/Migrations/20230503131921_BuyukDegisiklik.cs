using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    public partial class BuyukDegisiklik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesComments_AspNetUsers_ApplicationUserId",
                table: "MoviesComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesComments_Movies_MovieId",
                table: "MoviesComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRestriction_AspNetUsers_ApplicationUserId",
                table: "UserRestriction");

            migrationBuilder.DropTable(
                name: "ApplicationUserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ApplicationUserId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRestriction",
                table: "UserRestriction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesComments",
                table: "MoviesComments");

            migrationBuilder.RenameTable(
                name: "UserRestriction",
                newName: "UserRestrictions");

            migrationBuilder.RenameTable(
                name: "MoviesComments",
                newName: "MovieComment");

            migrationBuilder.RenameIndex(
                name: "IX_UserRestriction_ApplicationUserId",
                table: "UserRestrictions",
                newName: "IX_UserRestrictions_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesComments_MovieId",
                table: "MovieComment",
                newName: "IX_MovieComment_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesComments_ApplicationUserId",
                table: "MovieComment",
                newName: "IX_MovieComment_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserRestrictions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                columns: new[] { "ApplicationUserId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRestrictions",
                table: "UserRestrictions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieComment",
                table: "MovieComment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.ApplicationUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Like_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_MovieId",
                table: "Like",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComment_AspNetUsers_ApplicationUserId",
                table: "MovieComment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComment_Movies_MovieId",
                table: "MovieComment",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRestrictions_AspNetUsers_ApplicationUserId",
                table: "UserRestrictions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComment_AspNetUsers_ApplicationUserId",
                table: "MovieComment");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComment_Movies_MovieId",
                table: "MovieComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRestrictions_AspNetUsers_ApplicationUserId",
                table: "UserRestrictions");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRestrictions",
                table: "UserRestrictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieComment",
                table: "MovieComment");

            migrationBuilder.RenameTable(
                name: "UserRestrictions",
                newName: "UserRestriction");

            migrationBuilder.RenameTable(
                name: "MovieComment",
                newName: "MoviesComments");

            migrationBuilder.RenameIndex(
                name: "IX_UserRestrictions_ApplicationUserId",
                table: "UserRestriction",
                newName: "IX_UserRestriction_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComment_MovieId",
                table: "MoviesComments",
                newName: "IX_MoviesComments_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComment_ApplicationUserId",
                table: "MoviesComments",
                newName: "IX_MoviesComments_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserRestriction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRestriction",
                table: "UserRestriction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesComments",
                table: "MoviesComments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationUserMovie",
                columns: table => new
                {
                    LikedUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RatedMoviesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMovie", x => new { x.LikedUsersId, x.RatedMoviesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovie_AspNetUsers_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovie_Movies_RatedMoviesId",
                        column: x => x.RatedMoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ApplicationUserId",
                table: "Ratings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMovie_RatedMoviesId",
                table: "ApplicationUserMovie",
                column: "RatedMoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesComments_AspNetUsers_ApplicationUserId",
                table: "MoviesComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesComments_Movies_MovieId",
                table: "MoviesComments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRestriction_AspNetUsers_ApplicationUserId",
                table: "UserRestriction",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

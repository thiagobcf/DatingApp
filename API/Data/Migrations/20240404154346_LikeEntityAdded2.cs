using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class LikeEntityAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_likes_Users_SourceUserId",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_Users_TagerUserId",
                table: "likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_likes",
                table: "likes");

            migrationBuilder.RenameTable(
                name: "likes",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "TagerUserId",
                table: "Likes",
                newName: "TargetUserId");

            migrationBuilder.RenameIndex(
                name: "IX_likes_TagerUserId",
                table: "Likes",
                newName: "IX_Likes_TargetUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "SourceUserId", "TargetUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_SourceUserId",
                table: "Likes",
                column: "SourceUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_TargetUserId",
                table: "Likes",
                column: "TargetUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_SourceUserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_TargetUserId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "likes");

            migrationBuilder.RenameColumn(
                name: "TargetUserId",
                table: "likes",
                newName: "TagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_TargetUserId",
                table: "likes",
                newName: "IX_likes_TagerUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_likes",
                table: "likes",
                columns: new[] { "SourceUserId", "TagerUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_likes_Users_SourceUserId",
                table: "likes",
                column: "SourceUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_Users_TagerUserId",
                table: "likes",
                column: "TagerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

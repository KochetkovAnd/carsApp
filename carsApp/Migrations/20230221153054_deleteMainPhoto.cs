using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carsApp.Migrations
{
    /// <inheritdoc />
    public partial class deleteMainPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Photos_MainPhotoId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_MainPhotoId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "MainPhotoId",
                table: "Announcements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainPhotoId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_MainPhotoId",
                table: "Announcements",
                column: "MainPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Photos_MainPhotoId",
                table: "Announcements",
                column: "MainPhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

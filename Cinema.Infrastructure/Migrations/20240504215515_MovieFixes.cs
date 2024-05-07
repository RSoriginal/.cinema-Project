using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovieFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_seances_SeanceId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_SeanceId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SeanceId",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeanceId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_SeanceId",
                table: "Movies",
                column: "SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_seances_SeanceId",
                table: "Movies",
                column: "SeanceId",
                principalTable: "seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

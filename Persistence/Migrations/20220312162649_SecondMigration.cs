using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Categories_CategoryId",
                table: "Votes");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Categories_CategoryId",
                table: "Votes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Categories_CategoryId",
                table: "Votes");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Categories_CategoryId",
                table: "Votes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace AnkiAPI.Migrations
{
    public partial class InitialSecondTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Desks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desks_UserId",
                table: "Desks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Users_UserId",
                table: "Desks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Users_UserId",
                table: "Desks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Desks_UserId",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Desks");
        }
    }
}

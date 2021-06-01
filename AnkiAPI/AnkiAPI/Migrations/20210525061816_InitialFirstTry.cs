using Microsoft.EntityFrameworkCore.Migrations;

namespace AnkiAPI.Migrations
{
    public partial class InitialFirstTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeskId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeskId",
                table: "Cards",
                column: "DeskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Desks_DeskId",
                table: "Cards",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Desks_DeskId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DeskId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DeskId",
                table: "Cards");
        }
    }
}

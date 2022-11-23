using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonTodo.DAL.Migrations
{
    public partial class defaulttodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Order", "Title", "Url" },
                values: new object[] { 1, 1, "todo", "" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Order", "Title", "Url" },
                values: new object[] { 2, 2, "todo", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_Order",
                table: "Todos",
                column: "Order",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}

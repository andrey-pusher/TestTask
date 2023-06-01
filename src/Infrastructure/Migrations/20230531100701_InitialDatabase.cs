using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banks_total",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banks_total", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "banks_total",
                columns: new[] { "id", "bank", "total" },
                values: new object[,]
                {
                    { new Guid("4b928015-3861-413b-b8b1-4577007a0186"), 0, 0m },
                    { new Guid("44113f0f-0b46-4872-9791-4b4df718b82f"), 1, 0m },
                    { new Guid("02f2a68e-63d3-4f46-af7a-cae4b0fa0f9d"), 2, 0m },
                    { new Guid("33a67257-803f-4269-a5bb-002fc8d02bd7"), 3, 0m },
                    { new Guid("195ce1f6-5c92-4e6f-84db-04e8270b662a"), 4, 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banks_total");
        }
    }
}

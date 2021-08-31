using Microsoft.EntityFrameworkCore.Migrations;

namespace SalmonCookiesAPI.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumCustomers = table.Column<int>(type: "int", nullable: false),
                    MaximumCustomers = table.Column<int>(type: "int", nullable: false),
                    AverageCookiePerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AverageCookiePerSale", "Description", "Location", "MaximumCustomers", "MinimumCustomers", "Owner" },
                values: new object[] { 1, 2.5, "", "Seattle", 14, 4, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}

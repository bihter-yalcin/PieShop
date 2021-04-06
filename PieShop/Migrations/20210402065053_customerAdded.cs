using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class customerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pies_PieId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PieId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PieId",
                table: "Comments",
                column: "PieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pies_PieId",
                table: "Comments",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBuilder.Migrations
{
    /// <inheritdoc />
    public partial class PizzaSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Pizzas",
                newName: "SizeID");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeID",
                table: "Pizzas",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeID",
                table: "Pizzas",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeID",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SizeID",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "SizeID",
                table: "Pizzas",
                newName: "Size");
        }
    }
}

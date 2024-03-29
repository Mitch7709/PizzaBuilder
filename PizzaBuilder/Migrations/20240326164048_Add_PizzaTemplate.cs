using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaBuilder.Migrations
{
    /// <inheritdoc />
    public partial class Add_PizzaTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateToppings",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateToppings", x => new { x.TemplateID, x.ToppingID });
                    table.ForeignKey(
                        name: "FK_TemplateToppings_PizzaTemplates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "PizzaTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateToppings_Toppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateToppings_ToppingID",
                table: "TemplateToppings",
                column: "ToppingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateToppings");

            migrationBuilder.DropTable(
                name: "PizzaTemplates");
        }
    }
}

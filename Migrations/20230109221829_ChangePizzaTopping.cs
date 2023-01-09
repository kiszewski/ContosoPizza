using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class ChangePizzaTopping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Toppings_ToppingId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ToppingId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ToppingId",
                table: "Pizzas");

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzasId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToppingsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzasId, x.ToppingsId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizzas_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingsId",
                        column: x => x.ToppingsId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingsId",
                table: "PizzaTopping",
                column: "ToppingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.AddColumn<int>(
                name: "ToppingId",
                table: "Pizzas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ToppingId",
                table: "Pizzas",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Toppings_ToppingId",
                table: "Pizzas",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id");
        }
    }
}

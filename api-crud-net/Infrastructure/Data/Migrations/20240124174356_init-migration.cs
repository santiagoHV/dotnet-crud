using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_crud_net.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdPrice = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuNome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UsuPass = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuID);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedUsu = table.Column<int>(type: "int", nullable: false),
                    PedProd = table.Column<int>(type: "int", nullable: false),
                    PedCant = table.Column<int>(type: "int", nullable: false),
                    PedVrUnit = table.Column<decimal>(type: "Money", nullable: false),
                    PedSubTotal = table.Column<decimal>(type: "Money", nullable: false),
                    Decimal52 = table.Column<int>(name: "Decimal(5,2)", type: "int", nullable: false),
                    PedTotal = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Produtos_PedProd",
                        column: x => x.PedProd,
                        principalTable: "Produtos",
                        principalColumn: "ProdID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_PedUsu",
                        column: x => x.PedUsu,
                        principalTable: "Usuarios",
                        principalColumn: "UsuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedProd",
                table: "Pedidos",
                column: "PedProd");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedUsu",
                table: "Pedidos",
                column: "PedUsu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

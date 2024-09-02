using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boutique_zyx_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    NumeroPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaDespacho = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Vendedor = table.Column<int>(type: "int", nullable: false),
                    Repartidor = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.NumeroPedido);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    SKU = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Etiquetas = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UnidadMedida = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.SKU);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodigoTrabajador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Puesto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodigoTrabajador);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductoPedidos",
                columns: table => new
                {
                    NumeroPedido = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PedidoNumeroPedido = table.Column<int>(type: "int", nullable: true),
                    ProductoSKU = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPedidos", x => new { x.NumeroPedido, x.SKU });
                    table.ForeignKey(
                        name: "FK_ProductoPedidos_Pedidos_PedidoNumeroPedido",
                        column: x => x.PedidoNumeroPedido,
                        principalTable: "Pedidos",
                        principalColumn: "NumeroPedido");
                    table.ForeignKey(
                        name: "FK_ProductoPedidos_Productos_ProductoSKU",
                        column: x => x.ProductoSKU,
                        principalTable: "Productos",
                        principalColumn: "SKU");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPedidos_PedidoNumeroPedido",
                table: "ProductoPedidos",
                column: "PedidoNumeroPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPedidos_ProductoSKU",
                table: "ProductoPedidos",
                column: "ProductoSKU");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoPedidos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}

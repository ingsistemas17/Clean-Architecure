using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Api.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TEST_CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifiacion = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(maxLength: 300, nullable: false),
                    Telefono = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST_CLIENTE", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TEST_PRODUCTO",
                columns: table => new
                {
                    IdProducto = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    ValorUnidad = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST_PRODUCTO", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "TEST_FACTURA",
                columns: table => new
                {
                    IdFactura = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST_FACTURA", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_TEST_FACTURA_TEST_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TEST_CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TEST_FACTURA_DETALLE",
                columns: table => new
                {
                    IdFacturaDetalle = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    IdProducto = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ValorUnidad = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST_FACTURA_DETALLE", x => x.IdFacturaDetalle);
                    table.ForeignKey(
                        name: "FK_TEST_FACTURA_DETALLE_TEST_FACTURA_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "TEST_FACTURA",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEST_FACTURA_DETALLE_TEST_PRODUCTO_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "TEST_PRODUCTO",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TEST_FACTURA_IdCliente",
                table: "TEST_FACTURA",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TEST_FACTURA_DETALLE_IdFactura",
                table: "TEST_FACTURA_DETALLE",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_TEST_FACTURA_DETALLE_IdProducto",
                table: "TEST_FACTURA_DETALLE",
                column: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TEST_FACTURA_DETALLE");

            migrationBuilder.DropTable(
                name: "TEST_FACTURA");

            migrationBuilder.DropTable(
                name: "TEST_PRODUCTO");

            migrationBuilder.DropTable(
                name: "TEST_CLIENTE");
        }
    }
}

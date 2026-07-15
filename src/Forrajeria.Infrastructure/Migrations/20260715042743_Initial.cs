using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Forrajeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaConfirmacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaCancelacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Descuento = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "presentaciones_productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: false),
                    UnidadMedida = table.Column<int>(type: "integer", nullable: false),
                    CantidadUnidad = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    MargenGanancia = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presentaciones_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_presentaciones_productos_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalles_venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PresentacionProductoId = table.Column<int>(type: "integer", nullable: false),
                    DescripcionPresentacion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CantidadAVender = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    VentaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalles_venta_ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categorias_nombre",
                table: "categorias",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalles_venta_VentaId",
                table: "detalles_venta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_presentaciones_productos_ProductoId",
                table: "presentaciones_productos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_nombre",
                table: "productos",
                column: "nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "detalles_venta");

            migrationBuilder.DropTable(
                name: "presentaciones_productos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forrajeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregaRelacionProductoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaId",
                table: "productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_venta_PresentacionProductoId",
                table: "detalles_venta",
                column: "PresentacionProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalles_venta_presentaciones_productos_PresentacionProduct~",
                table: "detalles_venta",
                column: "PresentacionProductoId",
                principalTable: "presentaciones_productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_CategoriaId",
                table: "productos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalles_venta_presentaciones_productos_PresentacionProduct~",
                table: "detalles_venta");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_CategoriaId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_CategoriaId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_detalles_venta_PresentacionProductoId",
                table: "detalles_venta");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "productos");
        }
    }
}

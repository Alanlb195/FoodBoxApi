using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBoxApi.Migrations
{
    public partial class TablasCategoriaProductoySurcursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    categoriaId = table.Column<uint>(type: "int(8) unsigned zerofill", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.categoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_spanish_ci");

            migrationBuilder.CreateTable(
                name: "sucursal",
                columns: table => new
                {
                    sucursalId = table.Column<uint>(type: "int(8) unsigned zerofill", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    horario = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ubicacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ubicacionAdc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.sucursalId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_spanish_ci");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    productoId = table.Column<uint>(type: "int(8) unsigned zerofill", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombreImagen = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<int>(type: "int(5)", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_spanish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sucursalId = table.Column<uint>(type: "int(8) unsigned zerofill", nullable: false),
                    categoriaId = table.Column<uint>(type: "int(8) unsigned zerofill", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.productoId);
                    table.ForeignKey(
                        name: "ProductoCATGID-CategId",
                        column: x => x.categoriaId,
                        principalTable: "categoria",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ProductoSCID-SucursalID",
                        column: x => x.sucursalId,
                        principalTable: "sucursal",
                        principalColumn: "sucursalId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_spanish_ci");

            migrationBuilder.CreateIndex(
                name: "ProductoCATGID-CategId",
                table: "producto",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "ProductoSCID-SucursalID",
                table: "producto",
                column: "sucursalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "sucursal");
        }
    }
}

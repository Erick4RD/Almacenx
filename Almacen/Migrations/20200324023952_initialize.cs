using Microsoft.EntityFrameworkCore.Migrations;

namespace Almacen.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    empleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    puesto = table.Column<string>(maxLength: 30, nullable: false),
                    sueldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.empleadoId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    productosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Disponibilidad = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.productosID);
                });

            migrationBuilder.CreateTable(
                name: "provedores",
                columns: table => new
                {
                    provedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empresa = table.Column<string>(maxLength: 40, nullable: false),
                    productos = table.Column<string>(maxLength: 40, nullable: false),
                    contacto = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provedores", x => x.provedorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "provedores");
        }
    }
}

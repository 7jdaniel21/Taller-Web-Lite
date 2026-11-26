using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTallerLite.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdenesServiciosFacturacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAI",
                columns: table => new
                {
                    CAIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCAI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Establecimiento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PuntoEmision = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RangoInicial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RangoFinal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaLimiteEmision = table.Column<DateTime>(type: "date", nullable: false),
                    CorrelativoActual = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAI", x => x.CAIId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesTrabajo",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    MecanicoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Servicio = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesTrabajo", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Mecanicos_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mecanicos",
                        principalColumn: "MecanicoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesTrabajo_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "VehiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PrecioReferencia = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CAIId = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RTNCliente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NombreCliente = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    DireccionCliente = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    DescuentoTotal = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    ImpuestoTotal = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Emitida")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_Facturas_CAI_CAIId",
                        column: x => x.CAIId,
                        principalTable: "CAI",
                        principalColumn: "CAIId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_OrdenesTrabajo_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OrdenesTrabajo",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicios",
                columns: table => new
                {
                    OrdenServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CostoEstimado = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenServicios", x => x.OrdenServicioId);
                    table.ForeignKey(
                        name: "FK_OrdenServicios_OrdenesTrabajo_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OrdenesTrabajo",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenServicios_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    DetalleFacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    SubtotalLinea = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.DetalleFacturaId);
                    table.ForeignKey(
                        name: "FK_DetalleFactura_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAI_CodigoCAI",
                table: "CAI",
                column: "CodigoCAI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_CAIId",
                table: "Facturas",
                column: "CAIId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ClienteId",
                table: "Facturas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_NumeroFactura",
                table: "Facturas",
                column: "NumeroFactura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_OrdenId",
                table: "Facturas",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_MecanicoId",
                table: "OrdenesTrabajo",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesTrabajo_VehiculoId",
                table: "OrdenesTrabajo",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicios_OrdenId",
                table: "OrdenServicios",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicios_ServicioId",
                table: "OrdenServicios",
                column: "ServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "OrdenServicios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "CAI");

            migrationBuilder.DropTable(
                name: "OrdenesTrabajo");
        }
    }
}

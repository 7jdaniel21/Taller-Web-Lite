using AutoTallerLite.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoTallerLite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<OrdenTrabajo> OrdenesTrabajo { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<OrdenServicio> OrdenServicios { get; set; }
        public DbSet<CAI> CAIs { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdenTrabajo>(entity =>
            {
                entity.Property(o => o.Costo).HasPrecision(12, 2);
                entity.Property(o => o.Estado).HasDefaultValue("Pendiente");

                entity.HasOne(o => o.Vehiculo)
                    .WithMany()
                    .HasForeignKey(o => o.VehiculoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Mecanico)
                    .WithMany()
                    .HasForeignKey(o => o.MecanicoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.Property(s => s.PrecioReferencia).HasPrecision(12, 2);
            });

            modelBuilder.Entity<OrdenServicio>(entity =>
            {
                entity.Property(os => os.CostoEstimado).HasPrecision(12, 2);

                entity.HasOne(os => os.OrdenTrabajo)
                    .WithMany(o => o.OrdenServicios)
                    .HasForeignKey(os => os.OrdenId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(os => os.Servicio)
                    .WithMany(s => s.OrdenServicios)
                    .HasForeignKey(os => os.ServicioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CAI>(entity =>
            {
                entity.HasIndex(c => c.CodigoCAI).IsUnique();
                entity.Property(c => c.FechaLimiteEmision).HasColumnType("date");
                entity.Property(c => c.Estado).HasDefaultValue("Activo");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasIndex(f => f.NumeroFactura).IsUnique();
                entity.Property(f => f.Subtotal).HasPrecision(12, 2);
                entity.Property(f => f.DescuentoTotal).HasPrecision(12, 2);
                entity.Property(f => f.ImpuestoTotal).HasPrecision(12, 2);
                entity.Property(f => f.Total).HasPrecision(12, 2);
                entity.Property(f => f.Estado).HasDefaultValue("Emitida");

                entity.HasOne(f => f.OrdenTrabajo)
                    .WithMany(o => o.Facturas)
                    .HasForeignKey(f => f.OrdenId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Cliente)
                    .WithMany()
                    .HasForeignKey(f => f.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.AutorizacionCAI)
                    .WithMany(c => c.Facturas)
                    .HasForeignKey(f => f.CAIId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.Property(d => d.Cantidad).HasPrecision(12, 2);
                entity.Property(d => d.PrecioUnitario).HasPrecision(12, 2);
                entity.Property(d => d.Descuento).HasPrecision(12, 2);
                entity.Property(d => d.Impuesto).HasPrecision(12, 2);
                entity.Property(d => d.SubtotalLinea).HasPrecision(12, 2);

                entity.HasOne(d => d.Factura)
                    .WithMany(f => f.Detalles)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

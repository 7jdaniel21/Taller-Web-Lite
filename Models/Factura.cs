using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OrdenId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ClienteId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CAIId { get; set; }

        [Required]
        [StringLength(30)]
        public string NumeroFactura { get; set; } = string.Empty;

        [Required]
        public DateTime FechaEmision { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string? RTNCliente { get; set; }

        [Required]
        [StringLength(160)]
        public string NombreCliente { get; set; } = string.Empty;

        [StringLength(250)]
        public string? DireccionCliente { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal DescuentoTotal { get; set; }

        [Required]
        public decimal ImpuestoTotal { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Emitida";

        [ForeignKey(nameof(OrdenId))]
        public OrdenTrabajo OrdenTrabajo { get; set; } = null!;

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; } = null!;

        [ForeignKey(nameof(CAIId))]
        public CAI AutorizacionCAI { get; set; } = null!;

        public ICollection<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}

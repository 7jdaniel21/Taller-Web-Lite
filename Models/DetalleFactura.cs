using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("DetalleFactura")]
    public class DetalleFactura
    {
        [Key]
        public int DetalleFacturaId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int FacturaId { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal Descuento { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        [Required]
        public decimal SubtotalLinea { get; set; }

        [ForeignKey(nameof(FacturaId))]
        public Factura Factura { get; set; } = null!;
    }
}

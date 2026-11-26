using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("CAI")]
    public class CAI
    {
        [Key]
        public int CAIId { get; set; }

        [Required]
        [StringLength(100)]
        public string CodigoCAI { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string Establecimiento { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string PuntoEmision { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string RangoInicial { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string RangoFinal { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaLimiteEmision { get; set; }

        [Required]
        [StringLength(20)]
        public string CorrelativoActual { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Activo";

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}

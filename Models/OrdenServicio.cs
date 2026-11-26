using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("OrdenServicios")]
    public class OrdenServicio
    {
        [Key]
        public int OrdenServicioId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OrdenId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ServicioId { get; set; }

        [StringLength(250)]
        public string? Detalle { get; set; }

        [Required]
        public decimal CostoEstimado { get; set; }

        [ForeignKey(nameof(OrdenId))]
        public OrdenTrabajo OrdenTrabajo { get; set; } = null!;

        [ForeignKey(nameof(ServicioId))]
        public Servicio Servicio { get; set; } = null!;
    }
}

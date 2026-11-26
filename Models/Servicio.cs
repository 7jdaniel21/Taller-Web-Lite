using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("Servicios")]
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Descripcion { get; set; }

        [Required]
        public decimal PrecioReferencia { get; set; }

        public ICollection<OrdenServicio> OrdenServicios { get; set; } = new List<OrdenServicio>();
    }
}

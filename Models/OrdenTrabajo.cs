using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("OrdenesTrabajo")]
    public class OrdenTrabajo
    {
        [Key]
        public int OrdenId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int VehiculoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MecanicoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(250)]
        public string Servicio { get; set; } = string.Empty;

        [Required]
        public decimal Costo { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente";

        [ForeignKey(nameof(VehiculoId))]
        public Vehiculo Vehiculo { get; set; } = null!;

        [ForeignKey(nameof(MecanicoId))]
        public Mecanico Mecanico { get; set; } = null!;

        public ICollection<OrdenServicio> OrdenServicios { get; set; } = new List<OrdenServicio>();

        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}

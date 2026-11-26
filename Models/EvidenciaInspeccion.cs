
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("EvidenciasInspeccion")]
    public class EvidenciaInspeccion
    {
        [Key]
        public int EvidenciaId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int InspeccionId { get; set; }

        [Required]
        [StringLength(500)]
        public string RutaArchivo { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Descripcion { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [ForeignKey(nameof(InspeccionId))]
        public Inspeccion Inspeccion { get; set; } = null!;
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("HistorialEstados")]
    public class HistorialEstado
    {
        [Key]
        public int HistorialId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OrdenId { get; set; }

        [Required]
        [StringLength(20)]
        public string EstadoAnterior { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string EstadoNuevo { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCambio { get; set; } = DateTime.Now;

        [StringLength(250)]
        public string? Observacion { get; set; }
    }
}

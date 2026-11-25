
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("Inspecciones")]
    public class Inspeccion
    {
        [Key]
        public int InspeccionId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OrdenId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [Range(0, int.MaxValue)]
        public int Kilometraje { get; set; }

        [Required]
        [StringLength(500)]
        public string CondicionGeneral { get; set; } = string.Empty;
    }
}

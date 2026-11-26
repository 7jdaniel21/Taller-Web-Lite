
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("ObservacionesOrden")]
    public class ObservacionOrden
    {
        [Key]
        public int ObservacionId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OrdenId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;
    }
}

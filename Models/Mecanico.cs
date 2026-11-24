using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTallerLite.Models
{
    [Table("Mecanicos")]
    public class Mecanico
    {
        [Key]
        public int MecanicoId { get; set; }

        [Required]
        [StringLength(120)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;
    }
}
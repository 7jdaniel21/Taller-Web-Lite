using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutoTallerLite.Models
{
    [Table("Vehiculos")]
    [Index(nameof(Placa), IsUnique = true)]
    public class Vehiculo
    {
        [Key]
        public int VehiculoId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(15)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int Anio { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_API.Domain.Entities
{
    public class Usuario
    {
        #region Propiedades
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Documento { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Contrasena { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }
        #endregion

        #region Relaciones
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;

        [ForeignKey("TipoDocumento")]
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; } = null!;
        #endregion
    }
}

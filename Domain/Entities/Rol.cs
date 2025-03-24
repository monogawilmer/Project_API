using System.ComponentModel.DataAnnotations;

namespace Project_API.Domain.Entities
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}

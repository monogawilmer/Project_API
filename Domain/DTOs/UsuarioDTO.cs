namespace Project_API.Domain.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public int RolId { get; set; }
        public RolDTO Rol { get; set; } = null!;

        public int TipoDocumentoId { get; set; }
        public TipoDocumentoDTO TipoDocumento { get; set; } = null!;
    }
}

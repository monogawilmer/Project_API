using Microsoft.EntityFrameworkCore;
using Project_API.Domain.Entities;

namespace Project_API.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        #region Instacia de Conexión de Modelos a BD
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

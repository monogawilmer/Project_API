using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Repositories
{
    public interface ITipoDocumentoRepository
    {
        Task<List<TipoDocumento>> GetAllAsync();
        Task<TipoDocumento?> GetByIdAsync(int id);
        Task AddAsync(TipoDocumento tipoDocumento);
        Task<bool> UpdateAsync(TipoDocumento tipoDocumento);
        Task<bool> DeleteAsync(int id);
    }
}

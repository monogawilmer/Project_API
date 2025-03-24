using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Services
{
    public interface ITipoDocumentoService
    {
        Task<List<TipoDocumento>> GetAllAsync();
        Task<TipoDocumento> GetByIdAsync(int id);
        Task<TipoDocumento> AddAsync(TipoDocumento tipoDocumento);
        Task<bool> UpdateAsync(TipoDocumento tipoDocumento);
        Task<bool> DeleteAsync(int id);
    }
}

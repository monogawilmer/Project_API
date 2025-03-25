using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Services
{
    public interface ITipoDocumentoService
    {
        Task<List<TipoDocumentoDTO>> GetAllAsync();
        Task<TipoDocumentoDTO> GetByIdAsync(int id);
        Task<TipoDocumentoDTO> AddAsync(TipoDocumento tipoDocumento);
        Task<bool> UpdateAsync(TipoDocumento tipoDocumento);
        Task<bool> DeleteAsync(int id);
    }
}

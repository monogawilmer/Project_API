using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces
{
    public interface ITipoDocumentoRepository
    {
        Task<List<TipoDocumento>> GetAll();
        Task<TipoDocumento?> GetById(int id);
        Task Add(TipoDocumento tipoDocumento);
        Task Update(TipoDocumento tipoDocumento);
        Task Delete(int id);
    }
}
